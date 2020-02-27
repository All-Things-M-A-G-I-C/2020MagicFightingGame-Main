using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : BaseHitbox
{

    //This class controls the players hitbox that detects if they are hit by an attack.


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHitbox()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(dimensions.x,dimensions.y,1));
    }
    private void OnDrawGizmos()
    {
        ShowHitbox();
    }

    public void TakeDamage(int damage)
    {
        myParent.GetComponent<player>().Health -= damage;
    }
}
