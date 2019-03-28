using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ToggleDependableHider: MonoBehaviour
{
    [SerializeField]
    public bool flag;
    [SerializeField]
    public int i = 1;

}


[CustomEditor(typeof(ToggleDependableHider))]
public class MyScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var myScript = target as ToggleDependableHider;

        myScript.flag = GUILayout.Toggle(myScript.flag, "Flag");

        if (myScript.flag)
            myScript.i = EditorGUILayout.IntSlider("I field:", myScript.i, 1, 100);

    }
}