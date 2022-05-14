using System;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : Fader
{
    [SerializeField] private Fader anagramTitle;
    [SerializeField] private Fader nameText;
    [SerializeField] private Fader inputPanel;
    [SerializeField] private Fader confirmButton;

    public override void FadeIn(Action OnComplete = null, float time = 1)
    {
        anagramTitle.Hide();
        inputPanel.Hide();
        confirmButton.Hide();
        anagramTitle.FadeIn(() =>
        {
            inputPanel.FadeIn(() =>
            {
                if (inputPanel.GetComponent<InputPanel>().Username != String.Empty)
                {
                    confirmButton.FadeIn();
                }
            }
                , time);
        }, time);
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnConfirmButtonPressed();
        }
    }

    public void OnConfirmButtonPressed()
    {
        InputPanel inputPanelScript = inputPanel.GetComponent<InputPanel>();
        Controller.Instance.OnUserDataEntered(inputPanelScript.Username);
    }
}