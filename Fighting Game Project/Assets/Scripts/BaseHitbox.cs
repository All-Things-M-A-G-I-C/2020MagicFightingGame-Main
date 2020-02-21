using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHitbox : MonoBehaviour
{
    

    //Hitbox Dimensions
    public Vector2 dimensions;

    //Hitbox duration length
    public float duration;

    //the actual hitbox
    public BoxCollider myCollider;

    //who the hitbox belongs to
    public GameObject myParent;


    // Start is called before the first frame update
    void Awake()
    {
        myCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected virtual void MoveHitbox()
    {

    }
    public void SetDimensions()
    {
        myCollider.size = new Vector3(dimensions.x, dimensions.y, 1);
    }

}
