﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;

namespace Yort.Http.ClientPipeline.OAuth2
{
	/// <summary>
	/// Represents a simple/base OAuth 2.0 token (bearer style token).
	/// </summary>
	/// <remarks>
	/// <para>Other types of token, such as MAC tokens, should derive from this class and provide additional properties for the extra values required. They should also override the <see cref="SignRequest(HttpRequestMessage, OAuth2HttpRequestSigningMethod)"/> method if neccesary, to correctly sign requests made with this token.</para>
	/// </remarks>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated via Json deserialisation (reflection).")]
#if __IOS__
		[Foundation.Preserve]
#endif
	public class OAuth2Token
	{

		/// <summary>
		/// Default constructor.
		/// </summary>
#if __IOS__
			[Foundation.Preserve]
#endif
		public OAuth2Token()
		{
			Helper.Throw();
		}

		/// <summary>
		/// The access token value.
		/// </summary>
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }
		/// <summary>
		/// The type of token this class represents.
		/// </summary>
		[JsonProperty("token_type")]
		public string TokenType { get; set; }
		/// <summary>
		/// The life time in seconds of this token.
		/// </summary>
		[JsonProperty("expires_in")]
		public int ExpiresIn { get; set; }

		/// <summary>
		/// The calculated expiry date of the token.
		/// </summary>
		/// <remarks>
		/// <para>This value is based on the system clock. If the clients clock is incorrect, the calculated expiry will also be incorrect.</para>
		/// </remarks>
		public virtual DateTime? Expiry
		{
			get
			{
				Helper.Throw();

				return null;
			}
		}

		/// <summary>
		/// An optional refresh token used to renew the access token after it expires.
		/// </summary>
		[JsonProperty("refresh_token")]
		public string RefreshToken { get; set; }

		/// <summary>
		/// Signs the specified <see cref="HttpRequestMessage"/> using this token.
		/// </summary>
		/// <remarks>
		/// <para>Unless overridden this method signs the request by setting providing the token value (and token type as the 'scheme' if <param name="signingMethod"/>  is <see cref="OAuth2HttpRequestSigningMethod.AuthorizationHeader"/>).</para>
		/// </remarks>
		/// <param name="request">The <see cref="HttpRequestMessage"/> instance to be signed.</param>
		/// <exception cref="ArgumentNullException">Thrown if the <paramref name="request"/> argument is null.</exception>
		/// <exception cref="NotSupportedException">Thrown if an unknown or unsupported <paramref name="signingMethod"/> value is provided.</exception>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "OAuth")]
		public virtual void SignRequest(HttpRequestMessage request, OAuth2HttpRequestSigningMethod signingMethod)
		{
			Helper.Throw();
		}
	}
}