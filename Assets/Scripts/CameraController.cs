using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] float speed = 8;
	[SerializeField] GameObject target;
	[SerializeField] float cameraOffsetZ;
	//[SerializeField] float upMax = ;

	private Vector3 finalPos;

	// Update is called once per frame
	void FixedUpdate()
	{
		if (Input.GetAxis("Vertical") < 0)
		{
			transform.position = Vector3.Lerp(transform.position, new Vector2(target.transform.position.x, target.transform.position.y - 10), 2 * Time.deltaTime);
		}

		finalPos = new Vector3(target.transform.position.x + 1, target.transform.position.y + 7, cameraOffsetZ);
		transform.position = Vector3.Lerp(transform.position, finalPos, speed * Time.deltaTime);

	}
}

