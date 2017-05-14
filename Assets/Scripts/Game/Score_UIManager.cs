using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_UIManager : MonoBehaviour {
    public Text score;

	void Update () {
        score.text = carController.score.ToString();
	}
}
