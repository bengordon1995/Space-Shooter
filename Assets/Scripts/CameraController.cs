using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public GameObject camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float roll = Input.GetAxis("Horizontal");
		float pitch = Input.GetAxis("Vertical");

		camera.transform.position = (player.transform.position - player.transform.forward * 15f) + (player.transform.right) + (player.transform.up);
		camera.transform.LookAt(player.transform.position + player.transform.forward * 5f);
		camera.transform.rotation = player.transform.rotation;
	}
}
