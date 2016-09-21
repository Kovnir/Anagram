﻿using System;
﻿using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof (NamesBase))]
[CanEditMultipleObjects]
public class NamesBaseEditor : Editor
{
    private int selected = 0;

    private string str = null;

    public override void OnInspectorGUI()
    {
        NamesBase names = (NamesBase) target;

        EditorGUILayout.LabelField("Contains "+ names.names.Count + " names.");

        str = EditorGUILayout.TextArea(str);
        if (GUILayout.Button("Add to base"))
        {
            var list = str.Split('\n').ToList();
            list.ForEach(x =>
            {
                if (!names.names.Contains(x))
                {
                    names.names.Add(x);
                }
            });
            str = "";
        }

        if (GUILayout.Button("Remove \\r"))
        {
            names.names = names.names.Select(x => x.Replace("\r", String.Empty)).ToList();
        }
        EditorUtility.SetDirty(target);
    }
}