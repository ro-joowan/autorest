task 'copy-dts-files', '', (done)->
  # this needs to run multiple times.
  global.completed['copy-dts-files'] = false
  copyDtsFiles(done)
  return null

copyDtsFiles = (done) =>
  # copy *.d.ts files 
  source ["#{basefolder}/src/autorest-core/dist/**/*.d.ts","!#{basefolder}/src/autorest-core/dist/test/**" ]
    .pipe destination "#{basefolder}/src/autorest/lib/core"
    .on 'end', () => 
    source ["#{basefolder}/src/autorest-core/dist/**/*.d.ts","!#{basefolder}/src/autorest-core/dist/test/**" ]
      .pipe destination "#{basefolder}/src/autorest/dist/lib/core"
    .on 'end', () =>
     source ["#{basefolder}/src/autorest/vscode/**/*.d.ts" ]
      .pipe destination "#{basefolder}/src/autorest/dist/vscode"
    .on 'end', done
  return null

task 'fix-line-endings', 'typescript', ->
  typescriptFiles()
    .pipe eol {eolc: 'LF', encoding:'utf8'}
    .pipe destination 'src'

task 'clean' , 'typescript', (done)->
  typescriptProjectFolders()
    .pipe foreach (each,next)->
      rmdir "#{each.path}/dist/" , ->
        next null


task 'nuke' , 'typescript', (done)->
  typescriptProjectFolders()
    .pipe foreach (each,next)->
      rmdir "#{each.path}/node_modules/" , ->
        rmdir "#{each.path}/dist/" , ->
          next null

task 'test', 'typescript',['build/typescript'], (done)->
  typescriptProjectFolders()
    .pipe where (each) ->
      return test "-d", "#{each.path}/test"

    .pipe foreach (each,next)->
      execute "npm test", {cwd: each.path, silent:false }, (code,stdout,stderr) ->
        next null

task "compile/typescript", '' , (done)->  
  done()

task 'build', 'typescript', (done)-> 
  # watch for changes to these files and propogate them to the right spot.
  watcher = watchFiles ["#{basefolder}/src/autorest-core/dist/**/*.d.ts"], ["copy-dts-files"]
  
  typescriptProjectFolders()
    .on 'end', ->
      run 'compile/typescript', ->
        watcher._watcher.close() if !watch
        done()

    .pipe where (each ) ->
      return test "-f", "#{each.path}/tsconfig.json"
      
    .pipe foreach (each,next ) ->
      fn = filename each.path
      deps = ("compile/typescript/#{d.substring(d.indexOf('/')+1)}" for d in (global.Dependencies[fn] || []))
      
      task 'compile/typescript', fn, deps, (fin) ->
        copyDtsFiles ->
          execute "npm run build", {cwd: each.path }, (code,stdout,stderr) ->
            if watch
              execute "npm run watch", {cwd: each.path }, (c,o,e) ->
              echo "watching #{fn}"
              , (d) -> echo d.replace(/^src\//mig, "#{basefolder}/src/")
            fin()
          return null;
      next null
    return null

task 'npm-install', '', ['init-deps'], (done)-> 
  typescriptProjectFolders()
    .on 'end', -> 
      run 'npm-install', ->
        done()

    .pipe where (each ) -> 
      return test "-f", "#{each.path}/tsconfig.json"
      
    .pipe foreach (each,next ) ->
      fn = filename each.path
      deps =  ("npm-install/#{d.substring(d.indexOf('/')+1)}" for d in (global.Dependencies[fn] || []) )
      
      task 'npm-install', fn,deps, (fin) ->
        rm "#{each.path}/package-lock.json" if fileExists "#{each.path}/package-lock.json" 
        echo "Running npm install for #{each.path}."
        execute "npm install", {cwd: each.path, silent:false }, (code,stdout,stderr) ->
          fin()

      next null
    return null

