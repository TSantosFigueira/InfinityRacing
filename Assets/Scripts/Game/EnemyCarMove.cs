using UnityEngine;
using System.Collections;

//! Responsible for basic enemy and collectible movement
public class EnemyCarMove : MonoBehaviour {

	public float speed = 8f;

	void Update () {
        if(!Pause.isPaused)
		    transform.Translate (new Vector3(0, 1, 0) * -speed * Time.deltaTime);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
            gameObject.SetActive(false);
    }


}
