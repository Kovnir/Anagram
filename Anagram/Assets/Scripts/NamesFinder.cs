using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;

public class NamesFinder : MonoBehaviour
{
    public class NameSernamePare
    {
        public string name;
        public string sername;
        public NamesBase.Sex sex;

        public NameSernamePare(string name, string sername, NamesBase.Sex sex)
        {
            this.name = name;
            this.sername = sername;
            this.sex = sex;
        }

        public override string ToString()
        {
            return name + " " + sername;
        }
    }

    private List<NameSernamePare> result = new List<NameSernamePare>();

    private string username;

    private NamesBase maleBase;

    private NamesBase femaleBase;

    private SernamesBase sernamesBase;

    private bool complete;

    public event Action<List<NameSernamePare>> OnSearchingComplete;

    [UsedImplicitly]
    private void Start()
    {
        maleBase = Resources.Load("names/male") as NamesBase;
        femaleBase = Resources.Load("names/female") as NamesBase;
        sernamesBase = Resources.Load("names/SernamesBase") as SernamesBase;
    }

    [UsedImplicitly]
    private void Update()
    {
        if (complete)
        {
            if (OnSearchingComplete != null)
            {
                OnSearchingComplete.Invoke(result);
            }

            complete = false;
        }
    }

    public void Find(string username)
    {
        result = new List<NameSernamePare>();
        this.username = username.ToUpper();
        Thread t = new Thread(new ThreadStart(Find));
        t.Start();
    }

    private void Find()
    {
        Search(maleBase, username);
        Search(femaleBase, username);
        complete = true;
    }

    private void Search(NamesBase namesBase, string username)
    {
        List<string> namesList = namesBase.names;
        NamesBase.Sex sex = namesBase.nameSex;
        string usernameWithoutSpaces = username.Replace(" ", String.Empty);
        foreach (var name in namesList)
        {
            string bufName = usernameWithoutSpaces;
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
                if (bufName.Length > 1)
                {
                    //тут мы нашли имя. 
                    //надо проверить нет ли его ещё в базе (может другого пола). Если нет, надо найти фамилию
                    List<NameSernamePare> nameSernamePare;
                    lock (result)
                    {
                        nameSernamePare = result.FindAll(x => x.name == name);
                    }

                    if (nameSernamePare.Count > 0)
                    {
                        if (nameSernamePare[0].sex != sex)
                        {
                            nameSernamePare.ForEach(x =>
                            {
                                lock (x)
                                {
                                    x.sex = NamesBase.Sex.Both;
                                }
                            });
                        }
                        else
                        {
                            Debug.LogWarning("Something wrong!");
                        }
                    }
                    else
                    {
                        if (sernamesBase.SernameList.Count > bufName.Length)
                        {
                            List<string> correctSernames = sernamesBase.SernameList[bufName.Length - 1].sernames;
                            foreach (string sername in correctSernames)
                            {
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
                                        result.Add(new NameSernamePare(name, sername, sex));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

}
