using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Create New Class/DefaultClass")]
public class SO_CharacterClass : ScriptableObject
{
    //this class is responsible for storing moves, base stats, and basic animations for each unique character.


    public SO_AttackMove lightAttack;
    public SO_AttackMove mediumAttack;
    public SO_AttackMove HeavyAttack;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
