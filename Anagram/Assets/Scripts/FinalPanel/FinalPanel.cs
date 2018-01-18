using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FinalPanel : MonoBehaviour
{
    [SerializeField]
    private Fader bottomPanel;
    [SerializeField]
    private GameObject outputPanel;
    [SerializeField]
    private Fader anagramm;

    private List<RectTransform> charList;
    private List<RectTransform> workedPart;
    private List<float> places;

    private const int CHARS_COUNT = 22;

    private string userName;
    private string resultName;

    public void Change(string username, string resultName)
    {
        Transform panel = transform.Find("OutputPanel(Clone)");
        if (panel != null)
        {
            Destroy(panel.gameObject);
        }
        panel = Instantiate(outputPanel).transform; 
        panel.SetParent(this.transform, true);
        panel.transform.localPosition = Vector3.zero;
        charList = panel.GetComponent<OutputPanel>().charList;

        bottomPanel.Hide();
        anagramm.Hide();

        this.userName = username.ToUpper();
        this.resultName = resultName;
        workedPart = new List<RectTransform>();
        places = new List<float>();
        int difference = Mathf.Min(CHARS_COUNT - userName.Length, CHARS_COUNT);
        for (int i = 0; i < CHARS_COUNT; i++)
        {
            if (i < difference/2 || i >= difference / 2 + userName.Length)
            {
                charList[i].gameObject.SetActive(false);
            }
            else
            {
                workedPart.Add(charList[i]);
                places.Add(charList[i].anchoredPosition.x);
            }
        }
        for (int i = 0; i < workedPart.Count; i++)
        {
            workedPart[i].GetComponent<Text>().text = userName[i].ToString();
        }
        StartCoroutine(Change());
    }

    private IEnumerator Change()
    {
        yield return new WaitForSeconds(2);
        string currentname = userName;
        int index = 0;
        bool animationUp = true; 
        while (true)
        {
            for (index = 0; index < resultName.Count(); index++)
            {
                if (resultName[index] != currentname[index] && currentname[index] != ' ')
                {
                    break;
                }
            }
            if (index == resultName.Count())
            {
                break;
            }
            char flyingChar = currentname[index];
            currentname = Replace(currentname, index, ' ');
            RectTransform flyingTransform = workedPart[index];
            workedPart[index] = null;
            while (flyingChar != ' ')
            {
                //i = индект указывающий на новое место
                int i = 0;
                for (i = 0; i < resultName.Count(); i++)
                {
                    if (resultName[i] == flyingChar && currentname[i] != flyingChar)
                    {
                        break;
                    }
                }
                
                char bufChar = flyingChar;
                flyingChar = currentname[i];
                currentname = Replace(currentname, i, bufChar);

                RectTransform bufTransform = flyingTransform;
                flyingTransform = workedPart[i];
                workedPart[i] = bufTransform;

                bufTransform.DOAnchorPosY(places[i], 1).SetEase(Ease.InOutSine);
                float startYPosition = bufTransform.anchoredPosition.y;
                bufTransform.DOAnchorPosY(startYPosition + (animationUp? 1 : -1)* 40, 0.5f).SetEase(Ease.InOutSine).OnComplete(
                    () =>
                    {
                        bufTransform.DOAnchorPosY(startYPosition, 0.5f).SetEase(Ease.InOutSine);
                    });
                bufTransform.DOScale(1.5f, 0.5f).SetEase(Ease.InOutSine).OnComplete(() =>
                {
                    bufTransform.DOScale(1, 0.5f).SetEase(Ease.InOutSine);
                });
                animationUp = !animationUp;
                yield return new WaitForSeconds(0.5f);
            }
        }
        Debug.Log(currentname);
        bottomPanel.FadeIn();
        anagramm.FadeIn();
    }

    private string Replace(string str,int index, char newChar)
    {
        StringBuilder sb = new StringBuilder(str);
        sb[index] = newChar;
        return sb.ToString();
    }

    public void OnBackClicked()
    {
        Controller.Instance.BackToResultScreen();
    }

    public void OnTryAgainClicked()
    {
        Controller.Instance.BackToMainScreenFromFinalScreen();
    }
}