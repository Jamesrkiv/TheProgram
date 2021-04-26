using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMove : MonoBehaviour
{
	public float speed = 10f;
	public float gravity = 10f;
	public float jumpSpeed = 2.0f;
	public bool canMove = true;

	private CharacterController charContr;
	private Vector3 jumpVect = Vector3.zero;

	// Use this for initialization
	void Start()
	{
		charContr = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{
		float h = Input.GetAxis("Horizontal"); // Gets input axis
		float v = Input.GetAxis("Vertical");

		Vector3 forward = transform.forward * v * speed * Time.deltaTime; // Vector3 for movement
		Vector3 sideways = transform.right * h * speed * Time.deltaTime;
		Vector3 grav = new Vector3(0, -gravity, 0); // Gravity

		if (canMove && charContr.isGrounded) charContr.Move(forward + sideways + grav); // Moves object (player)
		else
		{
			charContr.Move(forward + sideways + (jumpVect * Time.deltaTime));
			jumpVect.y -= gravity * Time.deltaTime;
		}

		if (charContr.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
			jumpVect.y = jumpSpeed;
			charContr.Move(forward + sideways + (jumpVect * Time.deltaTime));
		}
		
	}
}
