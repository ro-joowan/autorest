namespace Fixtures.SwaggerBatHttp
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Test Infrastructure for AutoRest
    /// </summary>
    public partial interface IHttpRedirects
    {
        /// <summary>
        /// Return 300 status code and redirect to /http/success/200
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse> Head300WithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Return 300 status code and redirect to /http/success/200
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse<IList<string>>> Get300WithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Return 301 status code and redirect to /http/success/200
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse> Head301WithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Return 301 status code and redirect to /http/success/200
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse> Get301WithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Put true Boolean value in request returns 301.  This request
        /// should not be automatically redirected, but should return the
        /// received 301 to the caller for evaluation
        /// </summary>
        /// <param name='booleanValue'>
        /// Simple boolean value true
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse> Put301WithOperationResponseAsync(bool? booleanValue = default(bool?), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Return 302 status code and redirect to /http/success/200
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse> Head302WithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Return 302 status code and redirect to /http/success/200
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse> Get302WithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Patch true Boolean value in request returns 302.  This request
        /// should not be automatically redirected, but should return the
        /// received 302 to the caller for evaluation
        /// </summary>
        /// <param name='booleanValue'>
        /// Simple boolean value true
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse> Patch302WithOperationResponseAsync(bool? booleanValue = default(bool?), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Post true Boolean value in request returns 303.  This request
        /// should be automatically redirected usign a get, ultimately
        /// returning a 200 status code
        /// </summary>
        /// <param name='booleanValue'>
        /// Simple boolean value true
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse> Post303WithOperationResponseAsync(bool? booleanValue = default(bool?), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Redirect with 307, resulting in a 200 success
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse> Head307WithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Redirect get with 307, resulting in a 200 success
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse> Get307WithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Put redirected with 307, resulting in a 200 after redirect
        /// </summary>
        /// <param name='booleanValue'>
        /// Simple boolean value true
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse> Put307WithOperationResponseAsync(bool? booleanValue = default(bool?), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Patch redirected with 307, resulting in a 200 after redirect
        /// </summary>
        /// <param name='booleanValue'>
        /// Simple boolean value true
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse> Patch307WithOperationResponseAsync(bool? booleanValue = default(bool?), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Post redirected with 307, resulting in a 200 after redirect
        /// </summary>
        /// <param name='booleanValue'>
        /// Simple boolean value true
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse> Post307WithOperationResponseAsync(bool? booleanValue = default(bool?), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete redirected with 307, resulting in a 200 after redirect
        /// </summary>
        /// <param name='booleanValue'>
        /// Simple boolean value true
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<HttpOperationResponse> Delete307WithOperationResponseAsync(bool? booleanValue = default(bool?), CancellationToken cancellationToken = default(CancellationToken));
    }
}