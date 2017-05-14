using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//! Enables background track movement
public class trackMove : MonoBehaviour {

	public float speed;
    public Material phaseTrack;
    Vector2 offset;

    void Start()
    {    
        gameObject.GetComponent<MeshRenderer>().material = phaseTrack;              
    }
	

	void Update () {
        if (!Pause.isPaused)
        {
            offset = new Vector2(0, Time.time * speed);
            GetComponent<Renderer>().material.mainTextureOffset = offset;
        }
	
	}
}
