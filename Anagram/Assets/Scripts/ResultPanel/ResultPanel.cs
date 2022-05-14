using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{

    [SerializeField]
    private ResultBottomButton resultBottomButton;
    [SerializeField]
    private Transform resultBottomButtonHolder;
    [SerializeField]
    private GameObject backButton;
   [SerializeField]
    private GameObject tryAgainPanel;

    [SerializeField] private NamesPage namesPage;
    [SerializeField] private Text username;

    private int currentPageNum;

    private List<List<NamesFinder.NameSernamePare>> pages; 

    public const int NAMES_IN_PAGE = 8;

    private List<ResultBottomButton> resultBottomButtons;

    public void Init(List<NamesFinder.NameSernamePare> nameSernamePares, string username)
    {
        this.username.text = username;
        Debug.Log(nameSernamePares.Count +" matches.");
        pages = new List<List<NamesFinder.NameSernamePare>>();
        resultBottomButtons = new List<ResultBottomButton>();
        while (resultBottomButtonHolder.childCount > 0)
        {
            DestroyImmediate(resultBottomButtonHolder.GetChild(resultBottomButtonHolder.childCount - 1).gameObject);
        }
        for (int pageNum = 0; pageNum <  Math.Ceiling((double) nameSernamePares.Count / NAMES_IN_PAGE); pageNum ++)
        {
            pages.Add(new List<NamesFinder.NameSernamePare>());
            for (int i = 0; i < NAMES_IN_PAGE; i++)
            {
                if (nameSernamePares.Count > pageNum*NAMES_IN_PAGE + i)
                {
                    pages[pageNum].Add(nameSernamePares[pageNum * NAMES_IN_PAGE + i]);
                }
            }
            var button = Instantiate(resultBottomButton);
            button.transform.SetParent(resultBottomButtonHolder);
            button.Init(pageNum, pages[pageNum].Count, OnBottomButtonClick);
            resultBottomButtons.Add(button);
        }
        if (pages.Count > 0)
        {
            currentPageNum = 0;
            namesPage.Init(pages[0]);
            namesPage.gameObject.SetActive(true);
            resultBottomButtons[0].Select();
            tryAgainPanel.SetActive(false);
            backButton.SetActive(true);
        }
        else
        {
            namesPage.gameObject.SetActive(false);
            backButton.SetActive(false);
            tryAgainPanel.SetActive(true);
        }
    }

    private void OnBottomButtonClick(int index)
    {
        if (index != currentPageNum)
        {
            Fader fader = namesPage.GetComponent<Fader>();
            fader.FadeOut(
                () =>
                {
                    namesPage.Init(pages[index]);
                    fader.FadeIn(null, 0.1f);
                },0.1f);
            resultBottomButtons[currentPageNum].Deselect();
            currentPageNum = index;
        }
    }

    [UsedImplicitly]
    public void OnBackClicked()
    {
        Controller.Instance.BackToMainScreenFromResult();
    }
}
