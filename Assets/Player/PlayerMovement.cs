using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	private GameObject Food;
	//test

	[SerializeField]
	private Transform Resp;

	[SerializeField]
	private AudioSource HopSound;
	[SerializeField]
	private AudioSource LandSound;
	[SerializeField]
	private AudioSource TapSound;

	private void Start()
	{
		rb = this.GetComponent<Rigidbody2D>();
		HopSound = this.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		Move();
		Kill();
	}

	private void Kill()
	{
		if (rb.mass < 1)
		{
			Debug.Log("DED");
			rb.mass = 3;
			transform.position = Resp.transform.position;
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
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		if (jump)
		{
			HopSound.Play();
		}
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
			//Food = collision.transform.GetComponent<GameObject>();
			//if (Food == null)
			//{
			//	Debug.Log("LOl a bug2!");
			//	return;
			//}
			ChangeMass = fd.GetHealth();
			rb.mass += ChangeMass;
			Debug.Log("Mass: " + rb.mass);
			Debug.Log("ChangeMass: " + ChangeMass);
			Destroy(collision.gameObject);
		}
		if (collision.transform.tag == "Ded")
		{
			rb.mass = 0.1f;
			transform.position = Resp.transform.position;
			Debug.Log("fall");
		}
	}
}