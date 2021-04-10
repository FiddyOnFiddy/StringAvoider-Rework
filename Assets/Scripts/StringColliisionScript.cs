using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringColliisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] static int stringPointIntersectedWith;
    
    public static int StringPointIntersectedWith => stringPointIntersectedWith;

    [SerializeField] static bool isDead;

    public static bool IsDead
    {
        get { return isDead; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerDeathScript(collision);
    }

    void TriggerDeathScript(Collision2D collisionObject)
    {
        if(collisionObject.gameObject.tag == "String Point")
        {
            
            stringPointIntersectedWith = Int16.Parse(collisionObject.contacts[0].collider.name);
            isDead = true;
        }
    }
}
