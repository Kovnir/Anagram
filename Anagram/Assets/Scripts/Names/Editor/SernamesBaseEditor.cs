using System;
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

        EditorGUILayout.LabelField("Contains " + sernamesBase.sernames.Count + " names.");
        
        if (GUILayout.Button("Load base"))
        {
            string path = EditorUtility.OpenFilePanel("Choose a file", "", "txt");
            try
            {
                string line;
                StreamReader streamReader = new StreamReader(path);
                using (streamReader)
                {
                    do
                    {
                        line = streamReader.ReadLine();

                        if (line != null)
                        {
                            line = line.ToUpper();
                            if (!sernamesBase.sernames.Contains(line))
                            {
                                sernamesBase.sernames.Add(line);
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
        EditorUtility.SetDirty(target);
    }
}