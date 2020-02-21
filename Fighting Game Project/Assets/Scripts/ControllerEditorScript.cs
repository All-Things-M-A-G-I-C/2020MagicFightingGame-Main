using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ControllerScript))]
public class ControllerEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ControllerScript script = (ControllerScript)target;

        GUIContent controllerType = new GUIContent("Controller Type");
        script.controllerTypeIndex = EditorGUILayout.Popup(controllerType, script.controllerTypeIndex, script.controllerTypeList);
        
        GUIContent aButton = new GUIContent("A Button");
        GUIContent bButton = new GUIContent("B Button");
        GUIContent cButton = new GUIContent("C Button");
        GUIContent dButton = new GUIContent("D Button");

        string[] list;
        if (script.controllerTypeIndex == 0)
        {
            list = script.manager.buttonNameLists[0].ToArray();
        }
        else if (script.controllerTypeIndex == 1)
        {
            list = script.manager.buttonNameLists[1].ToArray();
        }
        else
        {
            list = script.manager.buttonNameLists[2].ToArray();
        }

        script.aButtonIndex = EditorGUILayout.Popup(aButton, script.aButtonIndex, list);
        script.bButtonIndex = EditorGUILayout.Popup(bButton, script.bButtonIndex, list);
        script.cButtonIndex = EditorGUILayout.Popup(cButton, script.cButtonIndex, list);
        script.dButtonIndex = EditorGUILayout.Popup(dButton, script.dButtonIndex, list);
    }
}
