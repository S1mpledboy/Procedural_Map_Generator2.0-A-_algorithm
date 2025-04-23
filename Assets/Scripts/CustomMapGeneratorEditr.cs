using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class CustomMapGeneratorEditr : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator generator = (MapGenerator)target;
        DrawDefaultInspector();
        if(GUILayout.Button("Randomize seed"))
        {
            generator.GenerateRandomOffset();
        }
    }

}
