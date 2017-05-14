using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//! This class manages all in-game related stuff
public class GameUIManager : MonoBehaviour {
    public Text score;

	void Start () {
		
	}
	

	void Update () {
        score.text = carController.score.ToString();
	}
}
