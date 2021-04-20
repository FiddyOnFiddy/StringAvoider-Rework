using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringCollisionScript : MonoBehaviour
{
    [SerializeField] static int stringPointIntersectedWith;

    public static int StringPointIntersectedWith => stringPointIntersectedWith;

    [SerializeField] static bool isDead;

    public static bool IsDead => isDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "String Point")
        {
            Debug.Log("Collided");
            stringPointIntersectedWith = Int16.Parse(collision.contacts[0].collider.name);
            isDead = true;
        }
    }
}
