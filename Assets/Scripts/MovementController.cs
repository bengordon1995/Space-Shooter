using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour {

	public float forceToHealthScaling;
	public float playerHealth;
	public GameObject player;
	public Rigidbody rigid;
	public float CONSTANT_VELOCITY;
	public Slider healthSlider;
	private float deathAnimStartTime;
	private float deathAnimTime;
	public float deathAnimTotalTime;
	public Animator animator;

	private float rotationZ;
	private float roll;
	private float pitch;
	private bool dead;

	// Use this for initialization
	void Start () {
		dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!dead){
			roll = Input.GetAxis("Horizontal") * 1.5f;
			animator.SetFloat("Horizontal",roll); 
			pitch = Input.GetAxis("Vertical") * 1.5f;
			animator.SetFloat("Vertical", -1f * pitch);
		}
		else{
			deathAnimTime += Time.deltaTime;
			rigid.AddTorque(rigid.transform.forward * 4f);
			if (deathAnimTime >= deathAnimTotalTime){
				SceneManager.LoadScene(0);
			}
		}
	}

	void FixedUpdate(){
		rigid.AddTorque(rigid.transform.forward * -1f *  roll);
		rigid.AddTorque(rigid.transform.right *  pitch);
		roll = 0f;
		pitch = 0f;
		rigid.AddForce(player.transform.forward * 10f);
		rigid.velocity = CONSTANT_VELOCITY * (rigid.velocity.normalized);

	}

	void OnCollisionEnter(Collision collision){
		float collisionForce = collision.relativeVelocity.magnitude;
		playerHealth -= collisionForce * forceToHealthScaling;
		healthSlider.value = playerHealth;

		if (playerHealth <= 0f){
			deathAnimStartTime = Time.time;
			dead = true;
		}
	}
}
