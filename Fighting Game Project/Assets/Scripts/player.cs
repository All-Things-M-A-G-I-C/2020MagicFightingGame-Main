using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //Hitbox that controls players running into eachother.
    
    //hitbox that controls when the player is attacked.
    public Hitbox hitBox;
    public HitBoxManager myHitBoxManager;

    //Input
    public ControllerManagerScript myInput;
    public int controllerPosition;
    public ControllerScript myController;
    public bool isPlayer;

    public int Health = 100;


    // Start is called before the first frame update
    void Start()
    {
        myHitBoxManager = FindObjectOfType<HitBoxManager>();
        myInput = FindObjectOfType<ControllerManagerScript>();
        myController = myInput.controllers[controllerPosition].GetComponent<ControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {

            GetInputs();
        }
        
    }

    public void TestAttack()
    {
        Vector3 temp = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        myHitBoxManager.SpawnAttackHitbox(gameObject, temp , new Vector2(1, 1), 2f, 10);
    }

    public void GetInputs()
    {
        
        if(myController.aButtonPressed)
        {
            TestAttack();
        }
    }

    //Movement
    





}
