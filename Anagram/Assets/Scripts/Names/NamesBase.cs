using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NamesBase", menuName = "NamesBase", order = 1)]
[Serializable]
public class NamesBase : ScriptableObject
{
    public enum Sex
    {
        Male,
        Female,
        Both,
    }

    public Sex nameSex;

    [SerializeField]
    public List<string> names = new List<string>();

    public override string ToString()
    {
        string str = String.Empty;
        names.ForEach(x => str += x+'\n');
        return str;
    }

}