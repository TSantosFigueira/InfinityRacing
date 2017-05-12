using UnityEngine;
using System.Collections;

//! Responsible for exhibiting the 'quit' scene as well as activating all of its animations
public class QuitManager : MonoBehaviour {

    public GameObject quit; //!< 'Quit' canvas to be exhibited
    private Animator quitAnimator;

    void Start()
    {     
        quitAnimator = quit.GetComponent<Animator>();
    }

    public void DisableQuitAnimation()
    {
        quitAnimator.SetBool("Display", false);

        // retrieves and plays selected sound
        GameObject.FindGameObjectWithTag("soundManager").GetComponent<Sounds>().playSound("button", 0.5f);

        StartCoroutine(WaitThenDoThings(quitAnimator.GetCurrentAnimatorClipInfo(0).Length));
    }

    public void EnableQuitAnimation()
    {
        quitAnimator.SetBool("Display", true);

        // retrieves and plays selected sound
        GameObject.FindGameObjectWithTag("soundManager").GetComponent<Sounds>().playSound("button", 0.5f);

        quit.GetComponent<Canvas>().sortingOrder = 110;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnableQuitAnimation();
        }
    }

    //! In quit scene, 'no' button was pressed 
    public void noPressed()
    {
        DisableQuitAnimation();
    }

    //! In quit scene, 'yes' button was pressed 
    public void GameQuit()
    {
        // retrieves and plays selected sound
        GameObject.FindGameObjectWithTag("soundManager").GetComponent<Sounds>().playSound("button", 0.5f);
        Application.Quit();
    }

    // Waits for animation to end in order to load new scene 
    IEnumerator WaitThenDoThings(float time)
    {
        yield return new WaitForSeconds(time);
        quit.GetComponent<Canvas>().sortingOrder = 80;
    }
}
