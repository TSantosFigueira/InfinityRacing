using UnityEngine;
using System.Collections;

//! In-game object spawner
public class EnemySpawner : MonoBehaviour {

    private int carNo;
    private Vector3 cam;
    private float maxPos = 2.2f;
	private float delayTime = 0.5f; //!< Time before the first objects start spawning
	private float timer; //!< Time between spawns

    public ObjectsPool[] pools;

	void Start () {
		timer = delayTime;

        // Determines maximum distance object (enemy/collectible) can go left/rigt based on screen size
        cam = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        maxPos = -cam.x - 0.5f;
    }
	
	void Update () {

		timer -= Time.deltaTime;
		if (timer <= 0) {
			Vector3 carPos = new Vector3(Random.Range(-maxPos, maxPos),transform.position.y,transform.position.z);
           
            // selects random pool from pools list
			carNo = Random.Range (0, pools.Length);
           
            // selects and activates object from the respective pool
            GameObject car = pools[carNo].getObject();
            car.transform.position = carPos;
            car.transform.rotation = Quaternion.identity;
            car.SetActive(true);

            timer = delayTime;
		}
	}
}
