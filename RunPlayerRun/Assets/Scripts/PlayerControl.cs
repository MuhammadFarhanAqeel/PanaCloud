using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {


	CharacterController controller;
	bool isGrounded = true;
	public float speed= 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	public GameControlScript control;
	private Vector3 moveDirection = Vector3.zero;
	public CountDownScript count;
	public PauseMenuScript pause;

	//audio source reference variable.	
	public AudioSource powerupCollectSound;
	public AudioSource jumpSound;
	public AudioSource snagSoundCollected;
	public AudioSource gameOverSound;


	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		if (controller.isGrounded) {

			animation.Play("run");

			if (pause.paused = false)
			{
				gameObject.GetComponent<AudioSource>().enabled = true;
			}
			else
			{
				gameObject.GetComponent<AudioSource>().enabled = true;
			}
			moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

			jumpSound.Stop();	
		}

		if (Input.GetButton ("Jump") && isGrounded == true) {
			isGrounded = false;
			animation.Stop("run");
			animation.Play("jump_pose");
			jumpSound.Play();
			gameObject.GetComponent<AudioSource>().enabled = false;
			moveDirection.y = jumpSpeed;
		}

		if (controller.isGrounded)
						isGrounded = true;
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);

		if (control.isGameOver) {
			gameObject.GetComponent<AudioSource> ().enabled = false;
		}
		else {
			gameOverSound.Play();
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "obsticle") {
			// do something
			Debug.Log("hit player!!");
			control.AlchoholCollected();
			snagSoundCollected.Play(); // playing the obsticle sound
		} 
		if (other.gameObject.tag == "Powerup") {
			control.PowerUpCollected();
			powerupCollectSound.Play (); // playing the powerup sound

		}
		
		Destroy(other.gameObject);
	}

}
