using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public int ControllerNum;
    public ControllerManagerScript manager;

    [HideInInspector]
    public int controllerTypeIndex = 2;
    [HideInInspector]
    public string[] controllerTypeList = new string[] { "PS4", "XBox", "Controller" };
    [HideInInspector]
    public int aButtonIndex = 0;
    [HideInInspector]
    public int bButtonIndex = 3;
    [HideInInspector]
    public int cButtonIndex = 2;
    [HideInInspector]
    public int dButtonIndex = 1;

    public bool upKeyPressed;
    public bool downKeyPressed;
    public bool leftKeyPressed;
    public bool rightKeyPressed;

    public bool aButtonPressed;
    public bool aButtonHeld;
    public bool bButtonPressed;
    public bool bButtonHeld;
    public bool cButtonPressed;
    public bool cButtonHeld;
    public bool dButtonPressed;
    public bool dButtonHeld;

    bool L2Pressed;
    bool R2Pressed;

    

    void Start()
    {
        manager = transform.parent.GetComponent<ControllerManagerScript>();
    }   
    void Update()
    {
        bButtonPressed = false;
        cButtonPressed = false;
        dButtonPressed = false;

        string aButtonName = "";
        string bButtonName = "";
        string cButtonName = "";
        string dButtonName = "";


        foreach (KeyValuePair<int, string[]> entry in manager.buttonNames)
        {
            string axis = "";
            if (entry.Key > 13)
            {
                axis = "axis ";
            }
            if (entry.Key == aButtonIndex)
            {
                aButtonName = axis + entry.Value[2];
            }
            if (entry.Key == bButtonIndex)
            {
                bButtonName = axis + entry.Value[2];
            }
            if (entry.Key == cButtonIndex)
            {
                cButtonName = axis + entry.Value[2];
            }
            if (entry.Key == dButtonIndex)
            {
                dButtonName = axis + entry.Value[2];
            }
        }

        aButtonPressed = Input.GetButtonDown("joystick " + ControllerNum + " " + aButtonName);
        bButtonPressed = Input.GetButtonDown("joystick " + ControllerNum + " " + bButtonName);
        cButtonPressed = Input.GetButtonDown("joystick " + ControllerNum + " " + cButtonName);
        dButtonPressed = Input.GetButtonDown("joystick " + ControllerNum + " " + dButtonName);

        aButtonHeld = Input.GetButton("joystick " + ControllerNum + " " + aButtonName);
        bButtonHeld = Input.GetButton("joystick " + ControllerNum + " " + bButtonName);
        cButtonHeld = Input.GetButton("joystick " + ControllerNum + " " + cButtonName);
        dButtonHeld = Input.GetButton("joystick " + ControllerNum + " " + dButtonName);

    }
}
