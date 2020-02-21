using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public GameObject anAttack;
    public GameObject aHitbox;




    // Start is called before the first frame update
    void Start()
    {
        SpawnHitBox(player1, player1.transform.position, new Vector2(1, 2));
        SpawnHitBox(player2, player2.transform.position, new Vector2(1, 2));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAttackHitbox(GameObject parent, Vector3 position, Vector2 dimensions,float duration,int damage)
    {
        GameObject temp = Instantiate(anAttack);
        temp.transform.position = position;
        temp.GetComponent<AttackBox>().myParent = parent;
        temp.GetComponent<AttackBox>().dimensions = dimensions;
        temp.GetComponent<AttackBox>().SetDimensions();
        temp.GetComponent<AttackBox>().damage = damage;
        temp.transform.parent = parent.transform;

        Destroy(temp, duration);




    }

    //Spawns the character hitbox and parents it with the given position and dimensions.
    //ToDo:remove a previous hitbox if present
    public void SpawnHitBox(GameObject parent,Vector3 position, Vector2 dimensions)
    {
        GameObject temp = Instantiate(aHitbox);
        temp.transform.position = position;
        temp.GetComponent<Hitbox>().myParent = parent;
        temp.GetComponent<Hitbox>().dimensions = dimensions;
        temp.GetComponent<Hitbox>().SetDimensions();
        temp.transform.parent = parent.transform;
        parent.GetComponent<player>().hitBox = temp.GetComponent<Hitbox>();
    }

}
