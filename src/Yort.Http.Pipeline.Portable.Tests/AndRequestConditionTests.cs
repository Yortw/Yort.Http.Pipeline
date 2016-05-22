﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yort.Http.Pipeline.Portable.Tests
{
	[TestClass]
	public class AndRequestConditionTests
	{

		[TestMethod]
		[TestCategory(nameof(AndRequestCondition))]
		[ExpectedException(typeof(System.ArgumentNullException))]
		public void AndRequestCondition_Constructor_ThrowsWhenChildConditionsNull()
		{
			var andCondition = new AndRequestCondition(null);
		}

		[TestMethod]
		[TestCategory(nameof(AndRequestCondition))]
		public void AndRequestCondition_Constructor_ConstructsOkWithEmptyChildConditions()
		{
			var andCondition = new AndRequestCondition(new IRequestCondition[] { });
		}

		[TestMethod]
		[TestCategory(nameof(AndRequestCondition))]
		public void AndRequestCondition_Constructor_ReturnsTrueIfAllChildConditionsPass()
		{
			var condition1 = new AuthorityHttpRequestCondition();
			condition1.AddAuthority("sometestsite");

			var condition2 = new RequestContentTypeCondition();
			condition2.AddContentMediaType(MediaTypes.TextPlain);

			var andCondition = new AndRequestCondition(new IRequestCondition[] { condition1, condition2 });

			var testRequest = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Post, "http://sometestsite/testendpoint");
			testRequest.Content = new System.Net.Http.StringContent("AAAABBBBCCCCDDD", System.Text.UTF8Encoding.UTF8, MediaTypes.TextPlain);

			Assert.IsTrue(andCondition.ShouldProcess(testRequest));
		}

		[TestMethod]
		[TestCategory(nameof(AndRequestCondition))]
		public void AndRequestCondition_Constructor_ReturnsFalseIfAnyChildConditionDoesNotPass()
		{
			var condition1 = new AuthorityHttpRequestCondition();
			condition1.AddAuthority("sometestsite");

			var condition2 = new RequestContentTypeCondition();
			condition2.AddContentMediaType(MediaTypes.TextPlain);

			var andCondition = new AndRequestCondition(new IRequestCondition[] { condition1, condition2 });

			var testRequest = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Post, "http://sometestsite/testendpoint");
			testRequest.Content = new System.Net.Http.StringContent("AAAABBBBCCCCDDD", System.Text.UTF8Encoding.UTF8, MediaTypes.ApplicationJson);

			Assert.IsFalse(andCondition.ShouldProcess(testRequest));
		}

	}
}