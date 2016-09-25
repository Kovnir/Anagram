using System;
using UnityEngine;
using UnityEngine.UI;

public class NamePanel : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private GameObject maleIcon;
    [SerializeField] private GameObject femaleIcon;
    [SerializeField] private GameObject bothIcon;

    public event Action<string> OnNameClick;

    public void OnClick()
    {
        if (OnNameClick != null) OnNameClick.Invoke(text.text);
    }

    public void Init(NamesFinder.NameSernamePare nameSernamePare)
    {
        text.text = nameSernamePare.ToString();
        maleIcon.SetActive(nameSernamePare.sex == NamesBase.Sex.Male);
        femaleIcon.SetActive(nameSernamePare.sex == NamesBase.Sex.Female);
        bothIcon.SetActive(nameSernamePare.sex == NamesBase.Sex.Both);
    }
}
