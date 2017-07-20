﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWallTrigger : MonoBehaviour {

	public bool goNextLvl;
	public bool isLastLvl;
	public bool isFirstLvl;

	bool allTouchedExitWall = false;
	public string nextLevelName;
	public float waitTime;
	public int fontSize;

	bool showMessage = false;
	public string nextPlayerMessage;

	void OnTriggerEnter2D(Collider2D other) {
		
		Debug.Log ("Collision with exit wall detected: " + other.gameObject.name);

		if (other.gameObject.tag == "Potato") {
			Destroy (other.gameObject);
		}

		if (!isFirstLvl) {
			GameObject frySpawner = GameObject.Find ("frySpawner");
			SpawnObjects fryScript = frySpawner.GetComponent<SpawnObjects> ();

			if (fryScript.friesLeft <= 0) {
				allTouchedExitWall = true;
			}
		}

		if (isFirstLvl) {
			GameObject fryspawner = GameObject.Find ("SwipeTester");
			SwipeFunctions fryScript = fryspawner.GetComponent<SwipeFunctions> ();

			if (fryScript.friesLeft <= 0) {
				allTouchedExitWall = true;
			}
		}

		//changes scene
		if (goNextLvl && allTouchedExitWall) {
			StartCoroutine ("WaitToLoad");
		}

		if (isLastLvl && allTouchedExitWall) {
			StartCoroutine ("Wait");
			//show end points 
		}
	}

	IEnumerator WaitToLoad() {
		yield return new WaitForSecondsRealtime (2);
		showMessage = true;
		yield return new WaitForSecondsRealtime (waitTime);
		Application.LoadLevel (nextLevelName);
	}

	IEnumerator Wait() {
		yield return new WaitForSecondsRealtime (3);
		showMessage = true;
	}

	void OnGUI() {

		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		centeredStyle.fontSize = fontSize;

		if (showMessage) {
			GUI.Label (new Rect (Screen.width/2 - 100, Screen.height/2 + 50, 200, 100), nextPlayerMessage, centeredStyle);
		}
	}
}
