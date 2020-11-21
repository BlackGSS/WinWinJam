using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
	PlayerMovement playerMovement;
	[SerializeField] float dashTime;
	[SerializeField] float dashCd;
	[SerializeField] float dashMultiplier;
	[SerializeField] Vector3 dashMovement;

	public Action onTouchFloor = () => { };

	// Start is called before the first frame update
	private void Start()
	{
		playerMovement = GetComponent<PlayerMovement>();
		onTouchFloor += onFloorTouched;

	}

	public Vector3 GetPositionToDash(bool jumping)
	{
		if (dashMovement == Vector3.zero)
		{
			StartCoroutine(TimeDashing(jumping));
			playerMovement.performingDash = true;

			return dashMovement = new Vector3(Input.GetAxis("Horizontal") * dashMultiplier, Input.GetAxis("Vertical") * dashMultiplier, 0);
		}
		else
		{
			return Vector3.zero;
		}
	}

	IEnumerator TimeDashing(bool jumping)
	{
		yield return new WaitForSeconds(dashTime);

		playerMovement.performingDash = false;

		if (jumping)
			Debug.Log("Waiting for touch ground to reset dash...");
		else
			StartCoroutine(DashCooldown());
	}

	IEnumerator DashCooldown()
	{
		yield return new WaitForSeconds(dashCd);

		dashMovement = Vector3.zero;
	}

	private void onFloorTouched()
	{
		dashMovement = Vector3.zero;
	}
}
