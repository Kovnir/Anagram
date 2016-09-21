using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;

public class NamesFinder : MonoBehaviour
{
    public delegate void ExampleCallback(int lineCount);

    private List<string> result = new List<string>();
    private string username = "Albert Katya asd";

    public event Action OnNameFounding;
    public event Action OnSearchComplete;

    private bool male;
    private bool female;

    private NamesBase maleBase;
   
    private NamesBase femaleBase;

    [UsedImplicitly]
    public void Start()
    {
        maleBase = Resources.Load("names/male") as NamesBase;
        femaleBase = Resources.Load("names/female") as NamesBase;
    }
    public void Find(string username, bool male, bool female)
    {
        this.male = male;
        this.female = female;
        this.username = username.ToUpper();
        Thread t = new Thread(new ThreadStart(Find));
        t.Start();
    }

    [UsedImplicitly]
    private void Update()
    {
        if (result.Count > 0)
        {
            lock (result)
            {
                while (result.Count > 0)
                {
                    Debug.Log(result[0]);
                    result.Remove(result[0]);
                }
            }
        }
    }

    private void Find()
    {
        List<string> namesList = new List<string>();
        if (male && female)
        {
            namesList = maleBase.names.Union(femaleBase.names).ToList();
        }
        else
        {
            if (male)
            {
                namesList = maleBase.names;
            }
            if (female)
            {
                namesList = femaleBase.names;
            }
        }

        foreach (var name in namesList)
        {
            string bufName = username;
            bool correct = false;
            foreach (char nameChar in name)
            {
                int index = bufName.IndexOf(nameChar);
                if (index == -1)
                {
                    correct = false;
                    break;
                }
                bufName = bufName.Remove(index, 1);
                correct = true;
            }
            if (correct)
            {
                lock (result)
                {
                    result.Add(name);
                }
            }
        }

        lock (result)
        {
            result.Add("Complete");
        }
    }
}
