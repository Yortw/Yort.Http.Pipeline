﻿using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Web.Http;
using Windows.Web.Http.Headers;
using Windows.Web.Http.Filters;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Yort.Http.ClientPipeline
{
	/// <summary>
	/// A delegating filter that automatically waits and retrieves when a 429 Too Many Requests response is received.
	/// </summary>
	public sealed class TooManyRequestsRetryFilter : RetryFilterBase
	{

		#region Constructors

		/// <summary>
		/// Full constructor.
		/// </summary>
		/// <param name="innerFilter">The next handler in the chain to pass requests onto.</param>
		public TooManyRequestsRetryFilter(IHttpFilter innerFilter) : base(innerFilter)
		{
		}

		/// <summary>
		/// Full constructor.
		/// </summary>
		/// <param name="innerFilter">The next handler in the chain to pass requests onto.</param>
		/// <param name="maxRetries">The maximum number of retries per initial request.</param>
		public TooManyRequestsRetryFilter(IHttpFilter innerFilter, int maxRetries) : base(innerFilter, maxRetries) 
		{
		}

		/// <summary>
		/// Full constructor.
		/// </summary>
		/// <param name="innerFilter">The next handler in the chain to pass requests onto.</param>
		/// <param name="maxRetries">The maximum number of retries per initial request.</param>
		/// <param name="maxPerRequestWaitTime">The maximum time to wait between retries. If the server requests a retry time greater than this the 429 response is returned an no wait/retry is performed. Specify <see cref="System.TimeSpan.Zero"/> for no limit.</param>
		public TooManyRequestsRetryFilter(IHttpFilter innerFilter, int maxRetries, TimeSpan maxPerRequestWaitTime) : base(innerFilter, maxRetries, maxPerRequestWaitTime)
		{
		}

		#endregion

		#region Overrides

		/// <summary>
		/// Returns true if the <paramref name="response"/> status code is <see cref="Windows.Web.Http.HttpStatusCode.TooManyRequests"/>.
		/// </summary>
		/// <param name="response">A <see cref="HttpResponseMessage"/> to be analysed.</param>
		/// <returns>True if the request should be retried, otherwise false.</returns>
		protected override bool ShouldRetry(HttpResponseMessage response)
		{
			if (response == null) return true;

			return response.StatusCode == HttpStatusCode.TooManyRequests;
		}

		#endregion

	}
}