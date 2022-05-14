using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof (SernameBase))]
[CanEditMultipleObjects]
public class SerbamesBaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SernameBase sernameBase = (SernameBase) target;

        EditorGUILayout.LabelField("Contains names:");

        for (int i = 0; i < sernameBase.SernameList.Count; i ++)
        {
            EditorGUILayout.LabelField(i+1 + " chars: \t" + sernameBase.SernameList[i].sernames.Count);
        }

        if (GUILayout.Button("Load base"))
        {
            string path = EditorUtility.OpenFilePanel("Choose a file", "", "txt");
            Load(path, sernameBase);
        }
        EditorUtility.SetDirty(target);
    }

    private void Load(string path, SernameBase sernameBase)
    {
        try
        {
            string line;
            StreamReader streamReader = new StreamReader(path);
            using (streamReader)
            {
                sernameBase.SernameList = new List<SernameBase.SameLengthSenameList>();
                do
                {
                    line = streamReader.ReadLine();
                    if (line != null)
                    {
                        line = line.ToUpper();
                        int length = line.Length;
                        while (sernameBase.SernameList.Count < length)
                        {
                            sernameBase.SernameList.Add(new SernameBase.SameLengthSenameList());
                        }
                        if (!sernameBase.SernameList[length-1].sernames.Contains(line))
                        {
                            sernameBase.SernameList[length-1].sernames.Add(line);
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