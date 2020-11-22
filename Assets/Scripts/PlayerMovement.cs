﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] float speed = 8f;
	[SerializeField] float minJumpForce = 2f;
	[SerializeField] float currentJumpForce;
	[SerializeField] float maxJumpForce = 5f;
	[SerializeField] float gravity;

	[Header("Jump Ability")]
	[SerializeField] bool initializingJump;
	[SerializeField] bool pressingJumping;
	[SerializeField] bool performingJump;
	[SerializeField] int doubleJumpMultiplier = 1;

	[Header("Dash Ability")]
	public bool performingDash;
	[SerializeField] int dashMultiplier = 1;
	[SerializeField] Dash dashSkill;

	[Header("Equipment")]
	[SerializeField] bool headsetEquipment;
	[SerializeField] bool bootsEquipment;
	[SerializeField] bool wireEquipment;

	[Header("ObjetosActivar")]
	[SerializeField] GameObject head;
	[SerializeField] GameObject[] boots;
	[SerializeField] GameObject[] wire;

	[SerializeField] CharacterController controller;

	float directionY;
	Vector3 direction;
	bool canDoubleJump = false;

	Vector3 nextPos;

	[SerializeField] float fixZOffset = 0.05f;
	bool fixingZ = false;
    [SerializeField] bool changingLevel;

	//public LayerMask FloorMask, WallMask;
	//public GameObject Bullet;

	//private float FireRate = 0.2f;

	public static Action<BodyPart> onBodyPartGotIt = (BodyPart bodypart) => { };
	public static Action<Transform> onFallingFromLevel = (Transform point) => { };
	public static Action onLevelArrive = () => { };

	private bool LookRight = true;

	public Animator anim;

	private void Start()
	{
		currentJumpForce = minJumpForce;
		onBodyPartGotIt += AddBodyPart;
		onFallingFromLevel += FallingFromLevel;
		onLevelArrive += LevelArrived;
	}

	private void Update()
	{
		Inputs();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		DirDetect();

        if (!changingLevel)
        {
            if (!performingDash)
                Movement();
            else
                DashMovement();
        }
        else
        {
            transform.Translate((transform.position - nextPos).normalized * -Time.deltaTime * 10, Space.World);
            if ((transform.position - nextPos).y >= -0.1f && (transform.position - nextPos).y <= 0.1f)
            {
                changingLevel = false;
                Debug.Log("SALIR!!!!!!!!!!!!!!");
            }
        }
        //ShootSystem();
    }

	private void Inputs()
	{
		#region Jump

		if (Input.GetButton("Jump") && controller.isGrounded)
		{
			initializingJump = true;

			if (currentJumpForce < maxJumpForce)
				currentJumpForce += 0.05f;
		}

		if (Input.GetButtonUp("Jump"))
		{
			anim.SetBool("Jump", true);
			pressingJumping = true;
			performingJump = true;
		}

		#endregion

		#region Dash

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			if (!performingDash)
			{
				if (!performingJump && !controller.isGrounded)
				{
					Vector3 dashMovement = dashSkill.GetPositionToDash(true);
					if (dashMovement != Vector3.zero)
					{
						print("Dash");
						direction += dashMovement;
					}
				}
				else
				{
					Vector3 dashMovement = dashSkill.GetPositionToDash(performingJump);
					if (dashMovement != Vector3.zero)
					{
						print("Dash");
						direction += dashMovement;
					}
				}


			}
		}

		#endregion
	}

	private void Movement()
	{
		float horizontalInput = Input.GetAxis("Horizontal");

		direction = new Vector3(horizontalInput, 0, 0);

		if (controller.isGrounded)
		{
			if (headsetEquipment)
			{
				if (performingJump && !pressingJumping)
				{
					performingJump = false;
					anim.SetBool("Jump", false);

					dashSkill.onTouchFloor.Invoke();
				}

				directionY = 0;

				if (bootsEquipment)
					canDoubleJump = true;

				if (pressingJumping && initializingJump)
				{
					pressingJumping = false;
					initializingJump = false;

					directionY = currentJumpForce;
				}
				else if (!initializingJump)
				{
					currentJumpForce = minJumpForce;
				}
				//anim.SetBool("Land", true);
			}
		}
		else
		{
			if (headsetEquipment)
			{
				if (pressingJumping && canDoubleJump)
				{
					pressingJumping = false;
					directionY = currentJumpForce * doubleJumpMultiplier;
					canDoubleJump = false;
				}
				else if (!canDoubleJump)
				{
					pressingJumping = false;
				}
			}
		}

		if (!controller.isGrounded)
			directionY -= gravity * Time.deltaTime;

		direction.y = directionY;

		if ((transform.position.z < -fixZOffset || transform.position.z > fixZOffset) && controller.isGrounded)
		{
			direction.z -= fixZOffset;
			fixingZ = true;
		}

		controller.Move(direction * speed * Time.deltaTime);

		if ((transform.position.z > -fixZOffset && transform.position.z < fixZOffset) && fixingZ)
		{
			fixingZ = false;
			transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
		}
	}

	private void DashMovement()
	{
		controller.Move(direction * speed * Time.deltaTime);
	}

	private void DirDetect()
	{
		if (Input.GetAxis("Horizontal") > 0)
		{
			anim.SetBool("Walk", true);
			transform.rotation = Quaternion.Euler(0, 0, 0);
			LookRight = true;
		}
		else if (Input.GetAxis("Horizontal") < 0)
		{
			anim.SetBool("Walk", true);
			transform.rotation = Quaternion.Euler(0, 180, 0);
			LookRight = false;
		}
		else if (Input.GetAxis("Horizontal") == 0)
		{
			anim.SetBool("Walk", false);
		}
	}

	private void AddBodyPart(BodyPart part)
	{
		switch (part)
		{
			case BodyPart.HEAD:

				print(part);
				head.SetActive(true);
				headsetEquipment = true;

				break;

			case BodyPart.BOOTS:

				for (int i = 0; i < boots.Length; i++)
				{
					boots[i].SetActive(true);
				}

				bootsEquipment = true;
				break;

			case BodyPart.WIRE:

				for (int i = 0; i < wire.Length; i++)
				{
					wire[i].SetActive(true);
				}

				wireEquipment = true;
				break;
		}
	}

	private void FallingFromLevel(Transform point)
	{
		changingLevel = true;
		nextPos = point.position;

		//transform.position = Vector3.Lerp(transform.position, nextPos, 1000f);

		//StartCoroutine(GoingToLevel(point.position));
	}

	private void LevelArrived()
	{
		changingLevel = false;
	}

	//void OnTriggerEnter(Collider Col)
	//{
	//	if (Col.tag == "Collectable")
	//	{
	//		transform.parent = Col.transform.parent;
	//	}

	//	if (Col.tag == "Vacio")
	//	{
	//		SceneManager.LoadScene(1);
	//	}

	//	if (Col.tag == "Agujero")
	//	{
	//		transform.position = new Vector2(0, 0);
	//	}
	//	if (Col.tag == "Exit")
	//	{
	//		Application.Quit();
	//	}
	//}

	//void OnTriggerExit(Collider2D Col)
	//{
	//	if (Col.tag == "PhysicPlatform")
	//	{
	//		transform.parent = null;
	//	}
	//}
}
