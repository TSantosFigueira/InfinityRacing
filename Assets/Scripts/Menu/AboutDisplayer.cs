using UnityEngine;
using System.Collections;

//! Responsible for exhibiting the 'about' scene as well as activating all of its animations
public class AboutDisplayer : MonoBehaviour {

    public GameObject credits; //!< 'Credit' canvas to be exhibited
    private Animator creditsAnimator;

	void Start () {
        creditsAnimator = credits.GetComponent<Animator>();
	}
	
    public void DisplayCredits()
    {
        creditsAnimator.SetBool("Display", true);

        // retrieves and plays selected sound
        GameObject.FindGameObjectWithTag("soundManager").GetComponent<Sounds>().playSound("button", 0.5f);

        credits.GetComponent<Canvas>().sortingOrder = 110;
    }

    public void UndisplayCredits()
    {
        creditsAnimator.SetBool("Display", false);

        // retrieves and plays selected sound
        GameObject.FindGameObjectWithTag("soundManager").GetComponent<Sounds>().playSound("button", 0.5f);

        StartCoroutine(WaitThenDoThings(creditsAnimator.GetCurrentAnimatorClipInfo(0).Length));
    }

    // Waits for animation to end in order to load new scene 
    IEnumerator WaitThenDoThings(float time)
    {
        yield return new WaitForSeconds(time);
        credits.GetComponent<Canvas>().sortingOrder = 90;
    }
}
