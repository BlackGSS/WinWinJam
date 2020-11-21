using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalLanguage : MonoBehaviour
{
    public static string CurrentLanguage = "English";
    public Toggle toggleEnglish;
    public Toggle toggleSpanish;
    public Toggle toggleGalician;
    public bool isInMenu;

    void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }

    public string ReturnLanguage()
    {
        return (CurrentLanguage);
    }

    private void Start()
    {
        ChangeLanguage(CurrentLanguage);
        print(CurrentLanguage);
    }

    public void ChangeLanguage (string language)
    {
        CurrentLanguage = language;
        NotificationCenter.DefaultCenter().PostNotification(this, "ChangeLanguage_P");

        if (isInMenu)
        {
            if(language == "Spanish")
            {
                toggleSpanish.isOn = true;
            }
            if (language == "English")
            {
                toggleEnglish.isOn = true;
            }
            if (language == "Galician")
            {
                toggleGalician.isOn = true;
            }
        }
    }
}
