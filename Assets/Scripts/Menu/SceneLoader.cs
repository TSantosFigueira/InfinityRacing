using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//! Responsible for loading new scenes with proper transition
public class SceneLoader : MonoBehaviour
{
    public string scene;
    public GameObject transition;

    public void Load()
    {
        GameObject.FindGameObjectWithTag("soundManager").GetComponent<Sounds>().playSound("button", 0.5f);
        transition.SetActive(true);
        StartCoroutine("LoadSceneAsync");
    }

    IEnumerator LoadSceneAsync()
    {
        yield return new WaitForSeconds(0.9f);

        AsyncOperation async = SceneManager.LoadSceneAsync(scene);

        while (!async.isDone)
        {
            yield return null;
        }
    }
}
