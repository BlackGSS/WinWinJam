using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
	[SerializeField] float speed = 8f;
	[SerializeField] float jumpForce;
	[SerializeField] float gravity;
	[SerializeField] CharacterController controller;
	[SerializeField] Rigidbody rigid;
	[SerializeField] float jumpPressedRememberTime = 0.2f;
	[SerializeField] float groundedRememberTime = 0.2f;
	float _directionY;
	int _doubleJumpMultiplier = 1;

	bool pressingJumping;

	//public LayerMask FloorMask, WallMask;
	//public GameObject Bullet;

	//private float FireRate = 0.2f;

	private bool LookRight = true;


	public Animator anim;
	private Vector3 moveDir;
	private bool _canDoubleJump;

	private void Update()
	{
		if (Input.GetButtonDown("Jump"))
			pressingJumping = true;
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		DirDetect();
		Movement();
		//ShootSystem();
	}

	private void Movement()
	{
		float horizontalInput = Input.GetAxis("Horizontal");

		Vector3 direction = new Vector3(horizontalInput, 0, 0);

		if (controller.isGrounded)
		{
			_directionY = 0;
			_canDoubleJump = true;

			if (pressingJumping)
			{
				pressingJumping = false;
				_directionY = jumpForce;
			}
		}
		else
		{
			if (pressingJumping && _canDoubleJump)
			{
				pressingJumping = false;
				_directionY = jumpForce * _doubleJumpMultiplier;
				_canDoubleJump = false;
			}
		}

		_directionY -= gravity * Time.deltaTime;

		direction.y = _directionY;

		controller.Move(direction * speed * Time.deltaTime);
	}

	//private void ShootSystem()
	//{
	//	FireRate = FireRate + Time.deltaTime;
	//	if (FireRate > 0.2f)
	//	{
	//		if (Input.GetKeyDown(KeyCode.Space))
	//		{
	//			if (LookRight == true)
	//			{
	//				GameObject NewBullet = (GameObject)Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 0));
	//				Destroy(NewBullet, 2);
	//			}
	//			if (LookRight == false)
	//			{
	//				GameObject NewBullet = (GameObject)Instantiate(Bullet, transform.position, Quaternion.Euler(180, 180, 0));
	//				Destroy(NewBullet, 2);
	//				print("Izquierda");
	//			}

	//			FireRate = 0;
	//		}
	//	}
	//}

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

	//public void GetDamage()
	//{
	//	Life = Life - 16;
	//	LifeBar.fillAmount = Life / 100;
	//	if (Life <= 0)
	//	{
	//		SceneManager.LoadScene(0);
	//	}
	//}

	void OnTriggerEnter2D(Collider2D Col)
	{
		if (Col.tag == "PhysicPlatform")
		{
			transform.parent = Col.transform.parent;
		}

		//if (Col.tag == "Enemy")
		//{
		//	GetDamage();
		//}

		if (Col.tag == "Vacio")
		{
			SceneManager.LoadScene(1);
		}

		if (Col.tag == "Agujero")
		{
			transform.position = new Vector2(0, 0);
		}
		if (Col.tag == "Exit")
		{
			Application.Quit();
		}
	}

	void OnTriggerExit2D(Collider2D Col)
	{
		if (Col.tag == "PhysicPlatform")
		{
			transform.parent = null;
		}
	}
}
