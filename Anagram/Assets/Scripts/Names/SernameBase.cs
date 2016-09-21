using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SernamesBase", menuName = "SernamesBase", order = 1)]
[Serializable]
public class SernamesBase : ScriptableObject
{
    [SerializeField]
    public List<string> sernames = new List<string>();
}