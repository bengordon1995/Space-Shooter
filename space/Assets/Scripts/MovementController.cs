using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	public float forceToHealthScaling;
	public float playerHealth;
	public GameObject player;
	public Rigidbody rigid;
	public float CONSTANT_VELOCITY;

	private float rotationZ;

	public float roll;
	public float pitch;
	public Vector3 forward;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		roll = Input.GetAxis("Horizontal");
		pitch = Input.GetAxis("Vertical");
	}

	void FixedUpdate(){
		rigid.AddTorque(rigid.transform.forward * -1f *  roll);
		rigid.AddTorque(rigid.transform.right *  pitch);
		roll = 0f;
		pitch = 0f;
		rigid.AddForce(player.transform.forward * 10f);
		forward = player.transform.forward;
		rigid.velocity = CONSTANT_VELOCITY * (rigid.velocity.normalized);
	}

	void OnCollisionEnter(Collision collision){
		float collisionForce = collision.relativeVelocity.magnitude;
		playerHealth -= collisionForce * forceToHealthScaling;
	}
}
