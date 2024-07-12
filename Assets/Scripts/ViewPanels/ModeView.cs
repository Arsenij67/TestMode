using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeView : MovePanelView
{

    public string PersonalNameMode;

    private InstallingView InstallingPanel;

    public void ActivateInstallPanel()
    {
        InstallingPanel = GameObject.FindGameObjectWithTag("InstallingPanel").GetComponent<InstallingView>();
        StartCoroutine(InstallingPanel.UpdateProgress());
    
    }





}


public class MovePanelView : MonoBehaviour
{

    [SerializeField] protected float speed = 0.5f;


    public async void OpenPanel(Transform endPos)
    {
       
        await DOTween.Sequence().Append(transform.DOLocalMoveY(endPos.localPosition.y, speed, false)).AsyncWaitForCompletion();

    }
    public async void ClosePanel(RectTransform startPos)
    {
        await DOTween.Sequence().Append(transform.DOLocalMoveY(startPos.localPosition.y, speed, false)).AsyncWaitForCompletion();

    }

    public async void OpenPanelX(Transform endPos)
    {
        await DOTween.Sequence().Append(transform.DOLocalMoveX(endPos.localPosition.x, speed, false)).AsyncWaitForCompletion();

    }

    public async void ClosePanelX(Transform startPos)
    {
        await DOTween.Sequence().Append(transform.DOLocalMoveX(startPos.localPosition.x, speed, false)).AsyncWaitForCompletion();

    }

}


