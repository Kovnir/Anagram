using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine.UI;

public class StartPanel : Fader
{
    [SerializeField] private Fader anagramTitle;
    [SerializeField] private Fader inputPanel;
    [SerializeField] private Fader confirmButton;

    public override void FadeIn(Action OnComplete = null)
    {
        anagramTitle.FadeIn(() =>
        {
            inputPanel.FadeIn();
        });
        inputPanel.GetComponent<InputPanel>().DataCorrect += OnDataCorrect;
    }

    private void OnDataCorrect(bool isDataCorrect)
    {
        if (isDataCorrect)
        {
            confirmButton.GetComponent<Button>().interactable = true;
            confirmButton.FadeIn();
        }
        else
        {
            confirmButton.GetComponent<Button>().interactable = false;
            confirmButton.FadeOut();
        }
    }

    public void OnConfirmButtonPressed()
    {
        InputPanel inputPanelScript = inputPanel.GetComponent<InputPanel>();
        Controller.Instance.OnUserDataEntered(inputPanelScript.Username, inputPanelScript.Male, inputPanelScript.Female);
    }
}
