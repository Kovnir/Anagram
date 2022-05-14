using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SurnamesBase", menuName = "SurnamesBase", order = 1)]
[Serializable]
public class SurnameBase : ScriptableObject
{
    [System.Serializable]
    public class SameLengthSurnameList
    {
        [SerializeField]
        public List<string> surnames = new List<string>();
    }

    [SerializeField] public List<SameLengthSurnameList> SernameList = new List<SameLengthSurnameList>();
}