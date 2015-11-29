using UnityEngine;
using System.Collections;

namespace UnityTest {


	public class PlayerProjectileShooter : MonoBehaviour, IGunController {

		private GameObject prefab;
		private float cd;

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {
			
		if (Input.GetKeyDown(KeyCode.Mouse0)) fire();

		}

		#region IGunController implementation
		public void fire() {
			prefab = Resources.Load("projectile") as GameObject;
			GameObject projectile = Instantiate(prefab) as GameObject;
			projectile.transform.position = transform.position + Camera.main.transform.forward;

			Rigidbody rb = projectile.GetComponent<Rigidbody>();

			rb.velocity = Camera.main.transform.forward * 40; //40
			Destroy(projectile, 3f);

		}
		#endregion
	}

}
