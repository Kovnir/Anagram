using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine.UI;

public class Controller : Singleton<Controller>
{
    public static Controller Instance
    {
        get
        {
            return ((Controller)mInstance);
        }
        set
        {
            mInstance = value;
        }
    }

    [SerializeField] private Fader startPanel;
    [SerializeField] private Fader resultPanel;
    [SerializeField] private Fader loading;
    [SerializeField] private NamesFinder namesFinder;
    [SerializeField] private FinalPanel finalPanel;
    private string username;

    [UsedImplicitly]
    void Start()
    {
        startPanel.FadeIn();
    }

    public void OnUserDataEntered(string username)
    {
        this.username = username;
        startPanel.FadeOut();
        loading.FadeIn(() =>
        {
            namesFinder.Find(username);
            namesFinder.OnSearchingComplete += OnSearchingComplete;
        });
    }

    private void OnSearchingComplete(List<NamesFinder.NameSernamePare> obj)
    {
        namesFinder.OnSearchingComplete -= OnSearchingComplete;
        loading.FadeOut();
        resultPanel.gameObject.SetActive(true);
        resultPanel.FadeIn();
        resultPanel.GetComponent<ResultPanel>().Init(obj, username);
    }

    public void BackToMainScreenFromResult()
    {
        resultPanel.FadeOut(() =>
        {
            resultPanel.gameObject.SetActive(false);
            startPanel.GetComponent<CanvasGroup>().alpha = 1;
            startPanel.FadeIn();
        });
    }

    public void BackToMainScreenFromFinalScreen()
    {
        finalPanel.GetComponent<Fader>().FadeOut(() =>
        {
            finalPanel.gameObject.SetActive(false);
            startPanel.GetComponent<CanvasGroup>().alpha = 1;
            startPanel.FadeIn();
        });
    }

    public void OnNameSelected(string name)
    {
        resultPanel.FadeOut(() =>
        {
            resultPanel.gameObject.SetActive(false);
            finalPanel.gameObject.SetActive(true);
            finalPanel.Change(username, name);
            finalPanel.GetComponent<Fader>().FadeIn();
        });
    }

    public void BackToResultScreen()
    {
        finalPanel.GetComponent<Fader>().FadeOut(() =>
        {
            finalPanel.gameObject.SetActive(false);
            resultPanel.gameObject.SetActive(true);
            resultPanel.FadeIn();
        });
    }
}
