﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	float ChangeMass = 0;

	private Rigidbody2D rb;
	private Food fd;
	//test

	[SerializeField]
	private Transform Resp;

	[SerializeField]
	private List<float> Fat = new List<float>();
	private int fatindex = 3;

	private bool PlayerDed = false;
	private bool PlayerHurt = false;


	private void Start()
	{
		rb = this.GetComponent<Rigidbody2D>();
		rb.mass = Fat[fatindex];
		PlayerDed = false;
	}

	// Update is called once per frame
	void Update()
	{
		//Debug.Log("jumping "+ jump);
		Move();
		Kill();
	}

	private void Kill()
	{
		if (rb.mass < 0.5)
		{
			Debug.Log("DED");
			rb.mass = 3;
			rb.velocity = Vector3.zero;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
			PlayerDed = true;
		}
	}

	private void Move()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
	}

	void FixedUpdate()
	{
		// Move our character
		PlayerHurt = controller.Sounds(jump, horizontalMove, PlayerDed, PlayerHurt);
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.tag == "Food")
		{
			fd = collision.transform.GetComponent<Food>();
			if (fd == null)
			{
				Debug.Log("LOl a bug1!");
				return;
			}


			Debug.Log("ChangeMass before: " + fatindex + "/" + fd.GetHealth());
			Debug.Log("Mass before: " + rb.mass);

			fatindex += (int) fd.GetHealth();
			// Player is lover hp
			if (rb.mass > Fat[fatindex])
				PlayerHurt = true;

			rb.mass = Fat[fatindex];
			Debug.Log("Mass: " + rb.mass);
			Debug.Log("ChangeMass: " + fatindex + "/" + fd.GetHealth());
			Destroy(collision.gameObject);
		}
		
		if (collision.transform.tag == "Ded")
		{
			rb.mass = 0.1f;
			transform.position = Resp.transform.position;
			Debug.Log("fall");
		}


		if (collision.transform.tag == "Finish")
		{
			SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
		}

	}
}
