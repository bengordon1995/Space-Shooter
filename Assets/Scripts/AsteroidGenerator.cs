using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class AsteroidGenerator : MonoBehaviour {

	public float accel;
	public GameObject asteroidPrefab;
	public int maxAsteroids;
	public int currentAsteroids;
	public GameObject player;
	public float drawDistance;
	public float fogDistance;
	public float clipDistance;
	public float asteroidCheckFrequency;

	private float timeSinceAsteroidCheck;
	private List<GameObject> asteroids;
	

	// Use this for initialization
	void Start () {
		asteroids = new List<GameObject>();
		while(asteroids.Count < maxAsteroids){
			float newX = Random.Range(-1f, 1f) * clipDistance + player.transform.position.x;
			float newY = Random.Range(-1f, 1f) * clipDistance + player.transform.position.y;
			float newZ = Random.Range(-1f, 1f) * clipDistance + player.transform.position.z;
			Vector3 newAsteroidPosition = new Vector3(newX, newY, newZ) + player.transform.forward * 20f;
			GameObject newAsteroid = Instantiate(asteroidPrefab);
			newAsteroid.transform.position = newAsteroidPosition;
			asteroids.Add(newAsteroid);
			newAsteroid.AddComponent<AsteroidController>();
			newAsteroid.GetComponent<AsteroidController>().accel = accel;
			newAsteroid.GetComponent<AsteroidController>().velocity = 0f;;
			newAsteroid.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
			newAsteroid.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)), ForceMode.Impulse);
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject asteroid in asteroids){
			Vector3 distance = player.transform.position - asteroid.transform.position;
			//distance greater than draw distance
			if (distance.sqrMagnitude > (clipDistance * clipDistance)){
				Vector3 newAsteroidPosition = player.transform.forward * 80f + player.transform.right.normalized * Random.Range(-100f, 100f) + player.transform.up.normalized * Random.Range(-100f, 100f);
				newAsteroidPosition = newAsteroidPosition.normalized * 70f + player.transform.position;
				asteroid.transform.position = newAsteroidPosition;
			}
		}
	}
}
 
