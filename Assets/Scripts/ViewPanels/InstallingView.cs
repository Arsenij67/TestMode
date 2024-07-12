using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InstallingView : MovePanelView
{
    public TMP_Text TitleInstall;
    public Slider LoadingProgr;
    [SerializeField] private float TimeLoad = 2f;
    private float force = 0;
    public TMP_Text TextProgr;
    
    internal IEnumerator UpdateProgress()
    {

        LoadingProgr.value = 0;
        force = (1 / (TimeLoad * 4));
        while (LoadingProgr.value < LoadingProgr.maxValue)
        {
            LoadingProgr.value += force;
            TextProgr.text = (LoadingProgr.value * 100).ToString() + "%";
            yield return new WaitForSeconds(force);
        }
         
 
    
    }

    
}
