using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof (SernamesBase))]
[CanEditMultipleObjects]
public class SerbamesBaseEditor : Editor
{
    private int selected = 0;

    public override void OnInspectorGUI()
    {
        SernamesBase sernamesBase = (SernamesBase) target;

        EditorGUILayout.LabelField("Contains names:");

        for (int i = 0; i < sernamesBase.SernameList.Count; i ++)
        {
            EditorGUILayout.LabelField(i+1 + " chars: \t" + sernamesBase.SernameList[i].sernames.Count);
        }

        if (GUILayout.Button("Load base"))
        {
            string path = EditorUtility.OpenFilePanel("Choose a file", "", "txt");
            Load(path, sernamesBase);
        }
        EditorUtility.SetDirty(target);
    }

    private void Load(string path, SernamesBase sernamesBase)
    {
        try
        {
            string line;
            StreamReader streamReader = new StreamReader(path);
            using (streamReader)
            {
                sernamesBase.SernameList = new List<SernamesBase.SameLengthSenameList>();
                do
                {
                    line = streamReader.ReadLine();
                    if (line != null)
                    {
                        line = line.ToUpper();
                        int length = line.Length;
                        while (sernamesBase.SernameList.Count < length)
                        {
                            sernamesBase.SernameList.Add(new SernamesBase.SameLengthSenameList());
                        }
                        if (!sernamesBase.SernameList[length-1].sernames.Contains(line))
                        {
                            sernamesBase.SernameList[length-1].sernames.Add(line);
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