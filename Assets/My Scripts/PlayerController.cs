using UnityEngine;
using System;

namespace UnityTest {


	[Serializable]
	public class PlayerController{

    [Range (0, 400)]
    public float HP = 400f;

		private IPlayerController playerController;
    private IGunController gunController;

		public void ApplyDecrementHP() {
        playerController.decrementPlayerHealth();
        HP-=10f;
		}
    public void ApplyRespawn() {
      if (HP <= 0) {
        playerController.respawn();
        HP = 400;
      }
    }
    public float ReturnHP() {
      return HP;
    }
    public void ApplyFire() {
			gunController.fire();
		}
		public void SetPlayerController (IPlayerController playerController) {
			this.playerController = playerController;
		}
    public void SetGunController (IGunController gunController) {
			this.gunController = gunController;
		}

	}

}
