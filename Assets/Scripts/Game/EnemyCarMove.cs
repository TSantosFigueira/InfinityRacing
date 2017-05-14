using UnityEngine;
using System.Collections;

//! Responsible for basic enemy and collectible movement
public class EnemyCarMove : MonoBehaviour {

	public float speed = 8f;

	void Update () {
		transform.Translate (new Vector3(0, 1, 0) * -speed * Time.deltaTime);
	}
}
