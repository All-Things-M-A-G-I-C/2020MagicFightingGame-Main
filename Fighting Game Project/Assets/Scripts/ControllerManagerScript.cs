using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static InputEditorScript;

public class ControllerManagerScript : MonoBehaviour
{
    [HideInInspector]
    public Dictionary<int, string[]> buttonNames = new Dictionary<int, string[]>();
    [HideInInspector]
    public List<List<string>> buttonNameLists = new List<List<string>>();

    // public GameObject controllerPrefab;
    public List<GameObject> controllers = new List<GameObject>();
    
    string[] currentControllerArray;
    void Start()
    {
        buttonNames.Add(0, new string[] { "SquareButton", "AButton", "button 0" });
        buttonNames.Add(1, new string[] { "CrossButton", "BButton", "button 1" });
        buttonNames.Add(2, new string[] { "CircleButton", "XButton", "button 2" });
        buttonNames.Add(3, new string[] { "TriangleButton", "YButton", "button 3" });
        buttonNames.Add(4, new string[] { "L1Button", "LBButton", "button 4" });
        buttonNames.Add(5, new string[] { "R1Button", "RBButton", "button 5" });
        buttonNames.Add(6, new string[] { "L2Button", "BackButton", "button 6" });
        buttonNames.Add(7, new string[] { "R2Button", "StartButton", "button 7" });
        buttonNames.Add(8, new string[] { "ShareButton", "LSButton", "button 8" });
        buttonNames.Add(9, new string[] { "StartButton", "RSButton", "button 9" });
        buttonNames.Add(10, new string[] { "L3Button", null, "button 10" });
        buttonNames.Add(11, new string[] { "R3Button", null, "button 11" });
        buttonNames.Add(12, new string[] { "PSButton", null, "button 12" });
        buttonNames.Add(13, new string[] { "PadButton", null, "button 13" });
        buttonNames.Add(14, new string[] { "LeftStickX", "LeftStickX", "1" });
        buttonNames.Add(15, new string[] { "LeftStickY", "LeftStickY", "2" });
        buttonNames.Add(16, new string[] { "RightStickX", "SharedAxis", "3" });
        buttonNames.Add(17, new string[] { "RightStickY", "RightStickY", "4" });
        buttonNames.Add(18, new string[] { "L2Trigger", "RightStickX", "5" });
        buttonNames.Add(19, new string[] { "R2Trigger", "DPadX", "6" });
        buttonNames.Add(20, new string[] { "DPadX", "DPadY", "7" });
        buttonNames.Add(21, new string[] { "DPadY", null, "8" });
        buttonNames.Add(22, new string[] { null, "LTrigger", "9" });
        buttonNames.Add(23, new string[] { null, "RTrigger", "10" });

        buttonNameLists.Add(new List<string>());
        buttonNameLists.Add(new List<string>());
        buttonNameLists.Add(new List<string>());

        foreach (KeyValuePair<int, string[]> entry in buttonNames)
        {
            string axis = "";
            if (entry.Key > 13)
            {
                axis = "axis";
            }
            buttonNameLists[0].Add(entry.Value[0]);
            buttonNameLists[1].Add(entry.Value[1]);
            buttonNameLists[2].Add(axis + " " + entry.Value[2]);
        }

        currentControllerArray = Input.GetJoystickNames();
        ReconfigControllers();
    }
    void Update()
    {
        if (!currentControllerArray.SequenceEqual(Input.GetJoystickNames()))
        {
            currentControllerArray = Input.GetJoystickNames();
            ReconfigControllers();
        }
    }
    void ReconfigControllers()
    {
        SerializedObject serializedObject = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0]);
        SerializedProperty axesProperty = serializedObject.FindProperty("m_Axes");
        axesProperty.ClearArray();
        serializedObject.ApplyModifiedProperties();

        foreach (GameObject c in controllers)
        {
            Destroy(c);
        }
        controllers.Clear();

        for (int i = 1; i < Input.GetJoystickNames().Length + 1; i++)
        {
            int controllerType = 2;
            if (Input.GetJoystickNames()[i - 1].Length == 19)
            {
                controllerType = 0;
            }
            else if (Input.GetJoystickNames()[i - 1].Length == 33)
            {
                controllerType = 1;
            }
            if (Input.GetJoystickNames()[i - 1] != "")
            {
                GameObject newController = Instantiate(new GameObject());
                newController.name = "Controller " + i;
                newController.AddComponent<ControllerScript>();
                newController.GetComponent<ControllerScript>().ControllerNum = i;
                newController.GetComponent<ControllerScript>().controllerTypeIndex = controllerType;
                newController.transform.SetParent(this.transform);
                controllers.Add(newController);
                int j;
                for (j = 0; j < 24; j++)
                {
                    if (j < 14)
                    {
                        string name = "joystick " + i + " " + buttonNames[j][2];
                        AddAxis(new InputAxis()
                        {
                            name = name,
                            positiveButton = name,
                            type = AxisType.KeyOrMouseButton,
                            joyNum = i,
                        });
                    }
                    else
                    {
                        bool isInverted = false;
                        if (controllerType == 0)
                        {
                            if (j == 15 || j == 17)
                            {
                                isInverted = true;
                            }
                        }

                        int axis = Int16.Parse(buttonNames[j][2]);
                        AddAxis(new InputAxis()
                        {
                            name = "joyStick " + i + " axis " + buttonNames[j][2],
                            dead = 0.1f,
                            sensitivity = 1,
                            invert = isInverted,
                            type = AxisType.JoystickAxis,
                            axis = axis,
                            joyNum = i,
                        });
                    }
                } 
            }
        }
    }
}
