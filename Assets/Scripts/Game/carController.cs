﻿using UnityEngine;
using System.Collections;

//! Manages player's status, velocity and movement
public class carController : MonoBehaviour
{
    public float carSpeed;  //!< Player's velocity
    public static int life;
    public static int score; //!< Player's score

    private bool currentPlatformAndroid = false;
    private float maxPos;  //!< Maximum limits player can go left or right
    private Vector3 cam; 
    Vector3 position;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

#if UNITY_ANDROID
        currentPlatformAndroid = true;
#else
        currentPlatformAndroid = false;
#endif

    }

    void Start()
    {
        position = transform.position;
        score = 0;
        // Determines maximum distance player can go left/rigt based on screen size
        cam = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        maxPos = -cam.x - 0.5f;
    }

    void Update()
    {
        if (!currentPlatformAndroid)
        {
            position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
        }

        position = transform.position;
        position.x = Mathf.Clamp(position.x, -maxPos, maxPos);
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.SetActive(false);
        if (col.gameObject.tag == "enemy")
        {
            life--;
        }
        if(col.gameObject.tag == "collectible")
        {
            score += 100;
        }
    }

    public void MoveLeft ()
    {
        rb.velocity = new Vector2(-carSpeed, 0);
    }

    public void MoveRight ()
    {
        rb.velocity = new Vector2(carSpeed, 0);
    }

    public void SetVelocityZero ()
    {
        rb.velocity = Vector2.zero;
    }
}