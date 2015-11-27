﻿using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour {

	private Slider slider;
	private int playerHP;
	
	private bool sw;
	
	private GameObject respawnLoc;
	private GameObject player;
	
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked; //at the beginning, lock cursor to middle of screen 
		Cursor.visible = false; //at the beginning, the cursor is hidden (since it's locked to middle of screen)
	
	
		slider = GameObject.Find("PlayerSlider").GetComponent<Slider>();
		Assert.IsNotNull(slider, "Couldn't find player slider!");
		slider.minValue = 0;
		slider.maxValue = 400;
		playerHP = 400;
	
		sw = true;
		
		respawnLoc = GameObject.Find("PlayerRespawn");
		Assert.IsNotNull(respawnLoc, "Couldn't find respawn point!");
		
		player = GameObject.Find("Player");
		Assert.IsNotNull(player, "Couldn't find player prefab!");
	
	}
	
	// Update is called once per frame
	void Update () {
		
		slider.value = playerHP;
		//print(slider.value);
		if (playerHP <= 0 && sw == true) {
			sw = false;
			print("i'm dead!");
			respawn();
		}
		
		
		if (Input.GetKey(KeyCode.Escape)) {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		else {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;			
		}
	}
	
	void decrementPlayerHealth(){
		playerHP -= 10;
	}

	void respawn() {
		print("respawning now");
		player.transform.position = respawnLoc.transform.position;
		playerHP = 400;
		sw = true;
	}
}
