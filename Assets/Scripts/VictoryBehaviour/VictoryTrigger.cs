using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
	[SerializeField] int id;
	float delayToWin = 0.1f;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			StartCoroutine(LaunchWin());

	}

	IEnumerator LaunchWin()
	{
		yield return new WaitForSeconds(delayToWin);

		VictoryManager.onVictoryAchieve.Invoke(id);

		Destroy(gameObject);
	}
}
