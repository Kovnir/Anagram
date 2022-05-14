using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof (SurnameBase))]
[CanEditMultipleObjects]
public class SurnamesBaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SurnameBase surnameBase = (SurnameBase) target;

        EditorGUILayout.LabelField("Contains names:");

        for (int i = 0; i < surnameBase.SernameList.Count; i ++)
        {
            EditorGUILayout.LabelField(i+1 + " chars: \t" + surnameBase.SernameList[i].surnames.Count);
        }

        if (GUILayout.Button("Load base"))
        {
            string path = EditorUtility.OpenFilePanel("Choose a file", "", "txt");
            Load(path, surnameBase);
        }
        EditorUtility.SetDirty(target);
    }

    private void Load(string path, SurnameBase surnameBase)
    {
        try
        {
            string line;
            StreamReader streamReader = new StreamReader(path);
            using (streamReader)
            {
                surnameBase.SernameList = new List<SurnameBase.SameLengthSurnameList>();
                do
                {
                    line = streamReader.ReadLine();
                    if (line != null)
                    {
                        line = line.ToUpper();
                        int length = line.Length;
                        while (surnameBase.SernameList.Count < length)
                        {
                            surnameBase.SernameList.Add(new SurnameBase.SameLengthSurnameList());
                        }
                        if (!surnameBase.SernameList[length-1].surnames.Contains(line))
                        {
                            surnameBase.SernameList[length-1].surnames.Add(line);
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