using UnityEngine;
using System.Collections;

public class EnemyProjectileShooter : MonoBehaviour {

	private GameObject prefab;
	
	// Use this for initialization
	void Start () {
		prefab = Resources.Load("projectile_enemy") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void Fire() {
		GameObject projectile = Instantiate(prefab) as GameObject;
		projectile.transform.position = transform.position + transform.up;
		
		Rigidbody rb = projectile.GetComponent<Rigidbody>();
		
		rb.velocity = transform.up * 30;
		Destroy(projectile, 3f);
	
	}
	
	
}
