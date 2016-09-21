using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Fader : MonoBehaviour
{

    private CanvasGroup canvasGroup;

    public virtual void FadeIn (Action OnComplete = null)
	{
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1,1).OnComplete(() =>
        {
            if (OnComplete != null)
            {
                OnComplete();
            }
        });
	}
    public virtual void FadeOut (Action OnComplete = null)
	{
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        canvasGroup.DOFade(0,1).OnComplete(() =>
        {
            if (OnComplete != null)
            {
                OnComplete();
            }
        });
    }
}
