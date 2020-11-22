using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableLanguage : Language
{
	protected override void Start()
	{
		NotificationCenter.DefaultCenter().AddObserver(this, "ChangeLanguage_P");
	}

	public override string GetCurrentText()
	{
		if (GlobalLanguage.CurrentLanguage == "English")
			return english;
		
		if (GlobalLanguage.CurrentLanguage == "Spanish")
			return spanish;
		
		if (GlobalLanguage.CurrentLanguage == "Galician")
			return galician;

		return null;
	}
}
