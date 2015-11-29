using UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using NSubstitute;

namespace UnityTest {

	[TestFixture]
	[Category("Mocking Unit Tests")]
	public class MockingUnitTests {


		[Test]
		public void GunFireWorks() {
			var gunController = GetGunMock();
			var motor = GetControllerMock(gunController);

			motor.ApplyFire();
			gunController.Received(1).fire();

		}

		[Test]
		public void InitializePlayerHealthWorks() {
			var playerController = GetPlayerMock();
			var motor = GetControllerMock(playerController);
			Assert.AreEqual(400f,motor.ReturnHP());
		}

		[Test]
		public void DecrementPlayerHealthWorks() {
			var playerController = GetPlayerMock();
			var motor = GetControllerMock(playerController);
			float initHP = motor.ReturnHP();
			motor.ApplyDecrementHP();
			float finalHP = motor.ReturnHP();
			Assert.AreEqual(-10f,finalHP-initHP);
		}

		[Test]
		public void PlayerRespawnWorks() {
			var playerController = GetPlayerMock();
			var motor = GetControllerMock(playerController);

			motor.HP = 0;
			motor.ApplyRespawn();
			playerController.Received(1).respawn();
		}

		[Test]
		public void PlayerRespawnResetsHP() {
			var playerController = GetPlayerMock();
			var motor = GetControllerMock(playerController);

			motor.HP = 0;
			motor.ApplyRespawn();
			Assert.AreEqual(400f,motor.ReturnHP());
		}

		private IGunController GetGunMock ()
		{
			return Substitute.For<IGunController>();
		}
		private PlayerController GetControllerMock ( IGunController gunController )
		{
			var motor = Substitute.For<PlayerController>();
			motor.SetGunController (gunController);
			return motor;
		}

		private IPlayerController GetPlayerMock ()
		{
			return Substitute.For<IPlayerController>();
		}
		private PlayerController GetControllerMock (IPlayerController playerController)
		{
			var motor = Substitute.For<PlayerController>();
			motor.SetPlayerController(playerController);
			return motor;
		}


	}

}
