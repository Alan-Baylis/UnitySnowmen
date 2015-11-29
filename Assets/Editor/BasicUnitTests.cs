using UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using NSubstitute;

namespace UnityTest {

	[TestFixture]
	[Category("Basic Assertions")]
	public class BasicAssertions {

		[Test]
		public void PassingTest() {
			Assert.AreEqual(4, 2+2);
		}
		[Test]
		public void FailingTest() {
			Assert.AreEqual(3, 2+2);
		}

	}

}
