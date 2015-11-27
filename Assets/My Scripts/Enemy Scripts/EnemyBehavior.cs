using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour {


	private GameObject player;
	private Transform target;
	private int detectDistance;
	
	private int AIState;
	private int PatrolState;
	
	private Vector3 dir;
	
	public static bool canFire;
	private GameObject obj;
	private GameObject obj2;
	private float cd;
	private float bulletcounter;
	
	private Slider slider;
	private int enemyHP;
	
	private GameObject respawnLoc;
	private bool sw;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		target = player.transform;
		detectDistance = 35;
		
		AIState = 0;
		PatrolState = 0;
		
		canFire = true;
		bulletcounter = 0;
		
		obj = transform.Find("EnemyKey/EnemyGunTip").gameObject;
		obj2 = transform.Find("EnemyKey2/EnemyGunTip").gameObject;
		Assert.IsNotNull(obj, "Error! Could not find enemy gun");
		
		slider = GameObject.Find("Slider").GetComponent<Slider>();
		Assert.IsNotNull(slider, "Couldn't find enemy slider!");
		slider.minValue = 0;
		slider.maxValue = 100;
		enemyHP = 100;
		
		respawnLoc = GameObject.Find("EnemyRespawn");
		Assert.IsNotNull(respawnLoc, "Couldn't find respawn point!");
		sw = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		slider.value = enemyHP;
		if (enemyHP <= 0 && sw == true) {
			sw = false;
			print("enemy dead!");
			respawn();
		}
		
		if (Vector3.Distance(player.transform.position,transform.position) < detectDistance) 
			AIState = 1;
		else 
			AIState = 0;
		
			
			
		if (AIState == 0) {
			
			if (PatrolState == 0) {
				transform.position = transform.position + transform.forward * 0.1f;
				StartCoroutine(d0());
			}
			if (PatrolState == 1) {
				transform.Rotate(Vector3.up * Time.deltaTime*120);			
				StartCoroutine(d1());
			}

			if (PatrolState == 2) {
				transform.position = transform.position + transform.forward * 0.1f;
				StartCoroutine(d2());
			}	
			

		}
		
		if (AIState == 1) {
			
			//rotate to player always 
			dir= target.position - transform.position;
			dir.Normalize();
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);	

			
			if (canFire) {
				obj.SendMessage("Fire", SendMessageOptions.DontRequireReceiver);
				obj2.SendMessage("Fire", SendMessageOptions.DontRequireReceiver);
				cd = Time.time + 0.2f;
				canFire = false;
				bulletcounter++;
				
			}
			
			if (!canFire && Time.time > cd)
				canFire = true;
			
			if (bulletcounter == 2) {
				cd = Time.time + 1f;
				bulletcounter = 0;
				
			}

		}
		
	}
	
	
	IEnumerator d0() {
		yield return new WaitForSeconds(1.5f);
		PatrolState = 1;
	}
	IEnumerator d1() {
		yield return new WaitForSeconds(1.2f);
		PatrolState = 2;
	}	
	IEnumerator d2() {
		yield return new WaitForSeconds(1.5f);
		PatrolState = 0;
	}
	
	void decrementEnemyHealth(){
		enemyHP -= 10;
	}
	
	void respawn() {
		print("respawning now");
		transform.position = respawnLoc.transform.position;
		enemyHP = 100;
		sw = true;
	}
	
}
