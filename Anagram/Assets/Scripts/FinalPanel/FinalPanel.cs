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

    private const int CHARS_COUNT = 22;

    public void Change(string userName, string resultName)
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

        userName = userName.ToUpper();
        var workedPart = new List<RectTransform>();
        var places = new List<float>();
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
        StartCoroutine(Change(workedPart, places, userName, resultName));
    }

    private IEnumerator Change(List<RectTransform> workedPart, List<float> places, string currentName, string resultName)
    {
        yield return new WaitForSeconds(2);
        bool animationUp = true; 
        while (true)
        {
            int oldPlaceId = GetFirstIncorrectChar(currentName, resultName);
            if (oldPlaceId == resultName.Count())
            {
                break;
            }
            char flyingChar = currentName[oldPlaceId];
            currentName = Replace(currentName, oldPlaceId, ' ');
            
            RectTransform flyingTransform = workedPart[oldPlaceId];
            workedPart[oldPlaceId] = null;
            
            while (flyingChar != ' ')
            {
                int newPlaceId = GetNewPlace(flyingChar, resultName, currentName);

                char bufChar = flyingChar;
                flyingChar = currentName[newPlaceId];
                currentName = Replace(currentName, newPlaceId, bufChar);

                RectTransform bufTransform = flyingTransform;
                flyingTransform = workedPart[newPlaceId];
                workedPart[newPlaceId] = bufTransform;

                yield return Animate(bufTransform, places[newPlaceId], animationUp);
                animationUp = !animationUp;
            }
        }
        Debug.Log(currentName);
        bottomPanel.FadeIn();
        anagramm.FadeIn();
    }

    private IEnumerator Animate(RectTransform transformToAnimate, float place, bool animationUp)
    {
        float startYPosition = transformToAnimate.anchoredPosition.y;
        transformToAnimate.DOAnchorPosX(place, 1).SetEase(Ease.InOutSine);
        transformToAnimate.DOAnchorPosY(startYPosition + (animationUp ? 1 : -1) * 40, 0.5f).SetEase(Ease.InOutSine).OnComplete(
            () => { transformToAnimate.DOAnchorPosY(startYPosition, 0.5f).SetEase(Ease.InOutSine); });
        transformToAnimate.DOScale(1.5f, 0.5f).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            transformToAnimate.DOScale(1, 0.5f).SetEase(Ease.InOutSine);
        });
        yield return new WaitForSeconds(0.5f);
    }

    private int GetNewPlace(char flyingChar, string resultName, string currentName)
    {
        int i = 0;
        for (i = 0; i < resultName.Count(); i++)
        {
            if (resultName[i] == flyingChar && currentName[i] != flyingChar)
            {
                break;
            }
        }

        return i;
    }

    private int GetFirstIncorrectChar(string currentname, string result)
    {
        int index = 0;
        for (index = 0; index < result.Count(); index++)
        {
            //if not match or space
            if (result[index] != currentname[index] && currentname[index] != ' ')
            {
                break;
            }
        }

        return index;
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