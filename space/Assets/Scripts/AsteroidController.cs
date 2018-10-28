using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

	public float velocity;
	public float accel;
	private float drawDistance;
	public GameObject player;
	// Use this for initialization
	void Start () {
		drawDistance = 20f;
	}
	
	// Update is called once per frame
	void Update () {
		velocity += accel;
		Rigidbody rigid = this.GetComponent<Rigidbody>();
		rigid.velocity = rigid.velocity.normalized * velocity;
	}
}
