using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{

    public string spanish;
    public string english;
    public string galician;
    public bool isButton;
    public Toggle toggleSpanish;
    public Toggle toggleEnglish;
    public Toggle toggleGalician;

    public GlobalLanguage globalLanguage;

    // Start is called before the first frame update

    private void Awake()
    {
        globalLanguage = GameObject.Find("LanguageManager").GetComponent<GlobalLanguage>();
    }
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "ChangeLanguage_P");
        ChangeLanguage_P();
    }

    public void ChangeLanguage_P ()
    {
        if (globalLanguage.ReturnLanguage () == "Spanish")
        {
            if (isButton)
            {
                GetComponentInChildren<Text>().text = spanish;
            }
            else
            {
                GetComponent<Text>().text = spanish;
            }
        }
        if (globalLanguage.ReturnLanguage() == "English")
        {
            if (isButton)
            {
                GetComponentInChildren<Text>().text = english;
            }
            else
            {
                GetComponent<Text>().text = english;
            }
        }
        if (globalLanguage.ReturnLanguage() == "Galician")
        {
            if (isButton)
            {
                GetComponentInChildren<Text>().text = galician;
            }
            else
            {
                GetComponent<Text>().text = galician;
            }
        }
    }
}
