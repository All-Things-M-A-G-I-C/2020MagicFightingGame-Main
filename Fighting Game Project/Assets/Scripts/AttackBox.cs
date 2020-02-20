using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : BaseHitbox
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Hitbox>() && other.GetComponent<Hitbox>().myParent != myParent)
        {
            other.GetComponent<Hitbox>().TakeDamage(damage);
        }
    }

    public void ShowHitbox()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(dimensions.x, dimensions.y, 1));
    }

    private void OnDrawGizmos()
    {
        ShowHitbox();
    }
}
