﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour {

	public static int currSceneScore = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateScore (int addScore) {
		currSceneScore = currSceneScore + addScore;
		Debug.Log ("New Score: " + currSceneScore);
	}

	void OnGUI() {

		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		centeredStyle.fontSize = Screen.width/13;
		string showScore = "Score: " + currSceneScore;

		GUI.Label (new Rect (Screen.width/17*9, Screen.height/25, 200, 100), showScore, centeredStyle);

	}
}
