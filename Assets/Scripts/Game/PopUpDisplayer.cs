using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//!  Responsible for exhibiting the 'pop up' scene as well as activating all of its animations
public class PopUpDisplayer : MonoBehaviour {

    public GameObject popUpCanvas;
    public Button continueButton;
    public Text score;
    public Image Message;
    public Sprite paused;
    public Sprite gameOver;

    private Animator popUpAnimator;

    void Start()
    {
        popUpAnimator = popUpCanvas.GetComponent<Animator>();
    }

    public void DisplayCredits(bool isPaused)
    {
        popUpCanvas.SetActive(true);
        Pause.isPaused = true;
        popUpAnimator.SetBool("Display", true);

        score.text = "Score" + "\n" + carController.score;
        if (isPaused)
        {
            Message.sprite = paused;
            continueButton.onClick.AddListener(UndisplayCredits);
        }
        else
        {
            Message.sprite = gameOver;
            continueButton.onClick.AddListener(()=> SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        }
            
        PlaySoundEffect("button");
        popUpCanvas.GetComponent<Canvas>().sortingOrder = 110;
    }

    public void UndisplayCredits()
    {
        popUpAnimator.SetBool("Display", false);
        PlaySoundEffect("button");
        StartCoroutine(WaitThenDoThings(popUpAnimator.GetCurrentAnimatorClipInfo(0).Length));
    }

    // Waits for animation to end in order to load new scene 
    IEnumerator WaitThenDoThings(float time)
    {
        yield return new WaitForSeconds(time);
        popUpCanvas.GetComponent<Canvas>().sortingOrder = 90;
        popUpCanvas.SetActive(false);
        Pause.isPaused = false;
    }

    // retrieves and plays selected sound
    private void PlaySoundEffect(string sound)
    {
        if (GameObject.FindGameObjectWithTag("soundManager"))
            GameObject.FindGameObjectWithTag("soundManager").GetComponent<Sounds>().playSound(sound, 0.5f);
    }
}
