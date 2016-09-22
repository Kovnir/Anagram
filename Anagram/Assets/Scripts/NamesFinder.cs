using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;

public class NamesFinder : MonoBehaviour
{
    public struct NameSernamePare
    {
        public string name;
        public string sername;

        public NameSernamePare(string name, string sername)
        {
            this.name = name;
            this.sername = sername;
        }

        public override string ToString()
        {
            return name + " " + sername;
        }
    }

    private List<NameSernamePare> result = new List<NameSernamePare>();
    private List<string> withoutSernames = new List<string>();
    private string username = "Albert Katya asd";

    public event Action OnNameFounding;
    public event Action OnSearchComplete;

    private bool male;
    private bool female;

    private NamesBase maleBase;

    private NamesBase femaleBase;

    private SernamesBase sernamesBase;
    private bool findingComplete;

    [UsedImplicitly]
    public void Start()
    {
        maleBase = Resources.Load("names/male") as NamesBase;
        femaleBase = Resources.Load("names/female") as NamesBase;
        sernamesBase = Resources.Load("names/SernamesBase") as SernamesBase;
    }

    public void Find(string username, bool male, bool female)
    {
        findingComplete = false;
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
            string bufName = username.Replace(" ", String.Empty);
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

                lock (withoutSernames)
                {
                    withoutSernames.Add(name);
                }
                if (bufName.Length > 1)
                {
                    //тут мы нашли имя. Надо найти фамилию
                    foreach (var sername in sernamesBase.sernames)
                    {
                        if (sername.Length != bufName.Length)
                        {
                            continue;
                        }
                        string leftChars = bufName; //оставшиеся символы
                        foreach (char sernameChar in sername)
                        {
                            int index = leftChars.IndexOf(sernameChar);
                            if (index != -1)
                            {
                                leftChars = leftChars.Remove(index, 1);
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (leftChars.Length == 0)
                        {
                            lock (result)
                            {
                                result.Add(new NameSernamePare(name, sername));
                            }
                        }
                    }
                }
            }
        }

        lock (result)
        {
            result.Add(new NameSernamePare("Complite", "___"));
        }
        findingComplete = true;
    }
}
