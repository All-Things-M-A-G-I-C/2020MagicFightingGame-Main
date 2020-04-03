using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : BaseHitbox
{
    //this script is used for attack hitboxes and will look for other hitboxes.
    //Can Not Cancel Out Projectiles currently

    public int damage;
    public Vector2 knockbackDirection;
    public int knockbackForce;
    public int energyGain;
    public bool reverse;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Checks to see if the collider has a hitbox component and makes sure that the hitbox does not belong to the person launching the attack.
    //Currenty Not Possible for friendly fire.
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Hitbox>() && other.GetComponent<Hitbox>().myParent != myParent)
        {
            other.GetComponent<Hitbox>().TakeDamage(damage);
            KnockBackTarget(other.GetComponent<Hitbox>().myParent.GetComponent<Rigidbody>());
        }
    }


    //debug shows hitbox, dev purposes
    public void ShowHitbox()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(dimensions.x, dimensions.y, 1));
    }

    private void OnDrawGizmos()
    {
        ShowHitbox();
    }

    public void KnockBackTarget(Rigidbody target)
    {
        if(reverse)
        {
            target.AddForce(new Vector3(-knockbackDirection.x, knockbackDirection.y, 0) * knockbackForce);

        }
        else
        {
            target.AddForce(new Vector3(knockbackDirection.x, knockbackDirection.y, 0) * knockbackForce);

        }
    }
}
