using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Fader : MonoBehaviour
{

    private CanvasGroup canvasGroup;

    public virtual void FadeIn (Action OnComplete = null, float time = 1f)
	{
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, time).OnComplete(() =>
        {
            if (OnComplete != null)
            {
                OnComplete();
            }
        });
	}
    public virtual void FadeOut (Action OnComplete = null, float time = 1f)
	{
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        canvasGroup.DOFade(0, time).OnComplete(() =>
        {
            if (OnComplete != null)
            {
                OnComplete();
            }
        });
    }

    public void Hide()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0;
    }
}
