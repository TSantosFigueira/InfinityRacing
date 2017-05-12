using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//! Enables fast scene transition between main menu and loaded scene
public class LoadScene : MonoBehaviour {

    public string sceneToLoad; //!< Scene that needs to be loaded
    public string mainMenu; //!< Main menu scene to load

    public void loadScene()
    {
        Time.timeScale = 1; // guarantees that any paused triggered event is removed
        SceneManager.LoadScene(sceneToLoad);
    }

    public void loadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenu);
    }
}
