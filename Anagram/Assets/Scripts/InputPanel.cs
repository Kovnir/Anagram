using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class InputPanel : MonoBehaviour
{
    [SerializeField]
    private Text nameHint;
    [SerializeField]
    private Text sexHint;

    private bool femaleToggle = true;
    private bool maleToggle = true;
    private string name = String.Empty;
    private bool dataCorrect;

    public event Action<bool> DataCorrect;

    public string Username
    {
        get { return name; }
    }
    public bool Male
    {
        get { return maleToggle; }
    } 
    public bool Female
    {
        get { return femaleToggle; }
    } 

    private void CheckData()
    {
        bool oldDataCorrect = dataCorrect;
        dataCorrect = true;
        if (name.Contains(" "))
        {
            nameHint.gameObject.SetActive(false);
        }
        else
        {
            dataCorrect = false;
        }

        if (maleToggle || femaleToggle)
        {
            sexHint.gameObject.SetActive(false);
        }
        else
        {
            sexHint.gameObject.SetActive(true);
            dataCorrect = false;
        }

        if (dataCorrect != oldDataCorrect)
        {
            if (DataCorrect != null)
                DataCorrect.Invoke(dataCorrect);
        }
    }

    public void OnNameValueChanged(string text)
    {
        name = text;
        CheckData();
    }

    public void OnNameValueChangingEnd(string text)
    {
        name = text;
        CheckData();
        if (!text.Contains(" "))
        {
            nameHint.gameObject.SetActive(true);
        }
        if (text.Length > 1)
        {
            nameHint.text = "Enter your second name too";
        }
        else
        {
            nameHint.text = "Enter your name";
        }
    }

    public void OnFemaleToggleValueChanged(bool value)
    {
        femaleToggle = value;
        CheckData();
    }
    public void OnMaleToggleValueChanged(bool value)
    {
        maleToggle = value;
        CheckData();
    }

}
