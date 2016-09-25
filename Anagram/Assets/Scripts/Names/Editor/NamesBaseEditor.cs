﻿using System;
﻿using System.Collections.Generic;
﻿using System.IO;
﻿using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof (NamesBase))]
[CanEditMultipleObjects]
public class NamesBaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        NamesBase names = (NamesBase) target;

        EditorGUILayout.LabelField("Contains "+ names.names.Count + " names.");

        names.nameSex = (NamesBase.Sex) EditorGUILayout.EnumPopup("Sex of name:", names.nameSex);
                if (GUILayout.Button("Load base"))
        {
            string path = EditorUtility.OpenFilePanel("Choose a file", "", "txt");
            Load(path, names);
        }
        EditorUtility.SetDirty(target);
    }


    private void Load(string path, NamesBase namesBase)
    {
        try
        {
            string line;
            StreamReader streamReader = new StreamReader(path);
            using (streamReader)
            {
                namesBase.names = new List<string>();
                do
                {
                    line = streamReader.ReadLine();
                    if (line != null)
                    {
                        line = line.Replace("\r", String.Empty);
                        if (!namesBase.names.Contains(line))
                        {
                            namesBase.names.Add(line);
                        }
                    }
                } while (line != null);
                streamReader.Close();
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}