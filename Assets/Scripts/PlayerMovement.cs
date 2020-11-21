using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	[SerializeField] bool headset;
	[SerializeField] bool boots;
	[SerializeField] bool cable;

	[SerializeField] CharacterController controller;

	private float directionY;
	private Vector3 direction;
	private bool canDoubleJump = false;

	//public LayerMask FloorMask, WallMask;
	//public GameObject Bullet;

	//private float FireRate = 0.2f;

	private bool LookRight = true;

	public Animator anim;

	private void Start()
	{
		currentJumpForce = minJumpForce;
	}

	private void Update()
	{
		Inputs();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		DirDetect();

		if (!performingDash)
			Movement();
		else
			DashMovement();

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
			if (performingJump && !pressingJumping)
			{
				performingJump = false;
				dashSkill.onTouchFloor.Invoke();
			}

			directionY = 0;

			//if (boots)
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
		}
		else
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

		directionY -= gravity * Time.deltaTime;

		direction.y = directionY;

		controller.Move(direction * speed * Time.deltaTime);
	}

	private void DashMovement()
	{
		controller.Move(direction * speed * Time.deltaTime);
	}

	private void DirDetect()
	{
		if (Input.GetAxis("Horizontal") > 0)
		{
			//anim.SetBool("Move", true);
			//transform.rotation = Quaternion.Euler(0, 0, 0);
			LookRight = true;
		}
		else if (Input.GetAxis("Horizontal") < 0)
		{
			//anim.SetBool("Move", true);
			//transform.rotation = Quaternion.Euler(0, 180, 0);
			LookRight = false;
		}
		else if (Input.GetAxis("Horizontal") == 0)
		{
			//anim.SetBool("Move", false);
		}
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
