using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
	[SerializeField] int id;
	float delayToWin = 0.5f;

	private void OnTriggerEnter(Collider other)
	{
		StartCoroutine(LaunchWin());

	}

	IEnumerator LaunchWin()
	{
		yield return new WaitForSeconds(delayToWin);

		VictoryManager.onVictoryAchieve.Invoke(id);
	}
}
