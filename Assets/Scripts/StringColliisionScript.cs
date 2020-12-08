using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringColliisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 stringPointIntersectedWith;

    public Vector3 StringPointIntersectedWith
    {
        get { return stringPointIntersectedWith; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerDeathScript(collision);
    }

    void TriggerDeathScript(Collision2D collisionObject)
    {
        if(collisionObject.gameObject.tag == "Wall")
        {
            Debug.Log("Collided");

        }
    }
}
