using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//! This class handles the back key pressed event on a phone or pc
public class BackKeyPressed : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.sceneCount == 0)
                GameObject.FindGameObjectWithTag("Quit").GetComponent<QuitManager>().EnableQuitAnimation();

            if (SceneManager.sceneCount == 1)
                GameObject.FindGameObjectWithTag("Pause").GetComponent<PopUpDisplayer>().DisplayCredits(true);
        }
		    
	}
}
