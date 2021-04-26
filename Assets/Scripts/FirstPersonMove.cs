using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMove : MonoBehaviour
{
	public float speed = 10f;
	public bool canMove = true;

	private CharacterController charContr;

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

		if (canMove) charContr.Move(forward + sideways); // Moves object (player)
	}
}
