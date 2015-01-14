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

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		if (controller.isGrounded) {
			animation.Play("run");
			moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
		}
		if (Input.GetButton ("Jump") && isGrounded == true) {
			isGrounded = false;
			animation.Stop("run");
			animation.Play("jump_pose");
			moveDirection.y = jumpSpeed;
		}
		if (controller.isGrounded)
						isGrounded = true;
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "obsticle") {
			// do something		
			Debug.Log("hit player!!");
			control.AlchoholCollected();
		} 
		if (other.gameObject.tag == "Powerup") {
			control.PowerUpCollected();		
		}
		
		Destroy(other.gameObject);
	}

}
