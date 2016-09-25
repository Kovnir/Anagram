using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultBottomButton : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private string numText;

    public void Init(int pageNum, int count, Action<int> onBottomButtonClick)
    {
        numText = (pageNum*ResultPanel.NAMES_IN_PAGE + 1) + "-" + (pageNum * ResultPanel.NAMES_IN_PAGE + count);
        text.text = numText;
        GetComponent<Button>().onClick.AddListener(() =>
        {
            onBottomButtonClick(pageNum);
            Select();
        });
    }

    public void Select()
    {
        text.fontSize = 16;
        text.text = "<b>" + numText + "</b>";
    }

    public void Deselect()
    {
        text.fontSize = 14;
        text.text = numText;
    }
}
