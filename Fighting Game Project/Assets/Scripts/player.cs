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

    public SO_CharacterClass myCharacter;



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
        if(myController == null)
        {
            myController = myInput.controllers[controllerPosition].GetComponent<ControllerScript>();

        }
        if (isPlayer)
        {

            GetInputs();
        }
        
    }

    public void TestAttack(SO_AttackMove anAttack)
    {
        Vector3 temp = new Vector3(transform.position.x + anAttack.attackLocation.x, transform.position.y + anAttack.attackLocation.y, transform.position.z + anAttack.attackLocation.z);
        myHitBoxManager.SpawnAttackHitbox(gameObject, temp , anAttack.attackSize, anAttack.attackDuration, anAttack.damage,anAttack.knockbackDirection,anAttack.knockbackForce,anAttack.energyGain);
    }

    public void GetInputs()
    {
        
        if(myController.aButtonPressed)
        {
            TestAttack(myCharacter.lightAttack);
        }
    }

    //Movement
    





}
