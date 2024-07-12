using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainWindowView : MovePanelView
{
    private string CurrentlangAnimName = "LanguageAnim@Open";
    [SerializeField] private GameObject panelLanguage = null;
    public string CurrentLang = "";
    protected LocalizationManager localization;

    [SerializeField] private AudioSource source;
    [SerializeField] private Image musicImage;
    [SerializeField] private Sprite sOn, sOff;

    private void Awake()
    {
        TryPlayMusic();
    }
    private string MusicActive
    {
        get => PlayerPrefs.GetString(nameof(MusicActive));
        set { PlayerPrefs.SetString(nameof(MusicActive), value.ToString()); }
    }

    public void ChangeLanguageAnim()
    {

        CurrentlangAnimName = CurrentlangAnimName.Equals("LanguageAnim@Close") ? "LanguageAnim@Open" : "LanguageAnim@Close";

        Animation animPanel = panelLanguage.GetComponent<Animation>();

        animPanel.clip = (animPanel.GetClip(CurrentlangAnimName));
        animPanel.PlayQueued(CurrentlangAnimName);
    }

    public void ChoseLang(string lang)
    {
        localization = GameObject.FindGameObjectWithTag("LocalizationManager").GetComponent<LocalizationManager>();
        localization.CurrentLanguage = CurrentLang = lang;
        Debug.Log(CurrentLang + " язык");
        Transform ButtonLang = GameObject.FindGameObjectWithTag(CurrentLang).transform;
        ButtonLang.SetSiblingIndex(1);

        localization.LoadLocalizedText(lang);
        localization.OnLanguageChanged.Invoke();


    }


    public void ChangeMusic()
    {
        MusicActive= (MusicActive.Equals("On")) ? "Off" : "On";

        TryPlayMusic();
    }

    private void TryPlayMusic()
    {
        if (MusicActive.Equals("On"))
        {
            musicImage.sprite = sOn;
            source.Play();
        }

        else
        {
            musicImage.sprite = sOff;
            source.Stop();
        }


    }
}
