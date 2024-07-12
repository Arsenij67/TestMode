using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LocaledText : MonoBehaviour
{
    [SerializeField] protected string key;
    protected LocalizationManager localization;
    protected TMP_Text text;

    private void Start()
    {
         

        if (localization == null)
        {

            localization = GameObject.FindGameObjectWithTag("LocalizationManager").GetComponent<LocalizationManager>();

        }
        if (text == null)
        {
            text = GetComponent<TMP_Text>();

        }
        localization.OnLanguageChanged += UpdateText;
        localization.OnLanguageChanged.Invoke();

       

    }


    public virtual void UpdateText()
    {
        print("kdfsds");

        if (key == "")
            {
                text.text = localization.GetLocalizedValue(text.text);
            }

            else
            {
           
            
                text.text = localization.GetLocalizedValue(key);
            }
             

         
        


    }


    private void OnDestroy()
    {

        localization.OnLanguageChanged -= UpdateText;
    
    
    }

}
