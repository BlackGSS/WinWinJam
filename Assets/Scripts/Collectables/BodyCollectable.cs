using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public enum BodyPart { HEAD = 0, WIRE, BOOTS }
public class BodyCollectable : Collactable
{
	[SerializeField] BodyPart category;
	[SerializeField] GameObject father;

	protected override void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			PlayerMovement.onBodyPartGotIt.Invoke(category);

			switch (category)
			{

				case BodyPart.HEAD:

					InitManager.onHeadTake.Invoke();

					break;

			}

			base.OnTriggerEnter(other);
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
	}
}