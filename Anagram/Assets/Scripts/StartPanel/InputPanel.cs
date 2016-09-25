using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InputPanel : MonoBehaviour
{
    private string userName = String.Empty;
    private bool dataCorrect;

    public event Action<bool> DataCorrect;

    public string Username
    {
        get { return userName; }
    }

    private void CheckData()
    {
        bool oldDataCorrect = dataCorrect;
        dataCorrect = true;
        List<string> wordList = userName.Split(' ').ToList();
        wordList = wordList.Where(x => (x != " " && x != String.Empty)).ToList();
        if (wordList.Count < 2)
        {
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
        userName = text;
        CheckData();
    }
}
