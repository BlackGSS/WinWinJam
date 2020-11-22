using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Language : MonoBehaviour
{
	public string spanish;
	public string english;
	public string galician;
	public bool isButton;

	protected virtual void Start()
	{
		NotificationCenter.DefaultCenter().AddObserver(this, "ChangeLanguage_P");
		ChangeLanguage_P();
	}

	public void ChangeLanguage_P()
	{
		if (GlobalLanguage.Instance.ReturnLanguage() == "Spanish")
		{
			if (isButton)
			{
				GetComponentInChildren<TextMeshProUGUI>().text = spanish;
			}
			else
			{
				GetComponent<TextMeshProUGUI>().text = spanish;
			}
		}
		if (GlobalLanguage.Instance.ReturnLanguage() == "English")
		{
			if (isButton)
			{
				GetComponentInChildren<TextMeshProUGUI>().text = english;
			}
			else
			{
				GetComponent<TextMeshProUGUI>().text = english;
			}
		}
		if (GlobalLanguage.Instance.ReturnLanguage() == "Galician")
		{
			if (isButton)
			{
				GetComponentInChildren<TextMeshProUGUI>().text = galician;
			}
			else
			{
				GetComponent<TextMeshProUGUI>().text = galician;
			}
		}
	}

	public virtual string GetCurrentText()
	{
		if (isButton)
		{
			return GetComponentInChildren<TextMeshProUGUI>().text;
		}
		else
		{
			return GetComponent<TextMeshProUGUI>().text = english;
		}
	}

}
