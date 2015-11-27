using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.tag == "Enemy") {
			print ("enemy tag");
			GameObject target = other.gameObject;
			target.SendMessage("decrementEnemyHealth", SendMessageOptions.DontRequireReceiver);
			
			Destroy(gameObject);
		}
			
	}
}
