using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SernamesBase", menuName = "SernamesBase", order = 1)]
[Serializable]
public class SernameBase : ScriptableObject
{
    [System.Serializable]
    public class SameLengthSenameList
    {
        [SerializeField]
        public List<string> sernames = new List<string>();
    }

    [SerializeField] public List<SameLengthSenameList> SernameList = new List<SameLengthSenameList>();
}