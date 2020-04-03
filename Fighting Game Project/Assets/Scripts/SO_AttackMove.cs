using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Create New Attack/BasicAttack")]
public class SO_AttackMove : ScriptableObject
{

    public Vector3 attackLocation;
    public Vector2 attackSize;
    public int damage;
    public int knockbackForce;
    public Vector2 knockbackDirection;
    public float attackDuration;
    public int energyGain;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
