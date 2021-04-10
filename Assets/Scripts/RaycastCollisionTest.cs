using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCollisionTest : MonoBehaviour
{
    [SerializeField] static int stringPointIntersectedWith;
    [SerializeField] static bool isDead;

    public static int StringPointIntersectedWith => stringPointIntersectedWith;
    public static bool IsDead
    {
        get { return isDead; }
    }

    RaycastHit2D topRay, bottomRay, leftRay, rightRay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CastRays();
    }


     void CastRays()
    {
        //Draw Line for top ray to detect collisions casting the length of the side (pivot/centre point has been set to bottom right to simplify distances of raycast
        topRay = Physics2D.Raycast(transform.localPosition + new Vector3(0, transform.localScale.y, 0), Vector2.right, transform.localScale.x, LayerMask.GetMask("String Point"));
        Debug.DrawRay(transform.localPosition + new Vector3(0, transform.localScale.y, 0), Vector2.right * transform.localScale.x, Color.red);

        //Draws bottom ray, starting (0,0) from bottom left, a.k.a transform.position of the wall the script is attached to.
        bottomRay = Physics2D.Raycast(transform.localPosition, Vector2.right, transform.localScale.x, LayerMask.GetMask("String Point"));
        Debug.DrawRay(transform.localPosition, Vector2.right * transform.localScale.x, Color.red);

        //Draws Left ray off set by scale used as length of the wall
        leftRay = Physics2D.Raycast(transform.localPosition, Vector2.up, transform.localScale.y, LayerMask.GetMask("String Point"));
        Debug.DrawRay(transform.localPosition, Vector2.up * transform.localScale.y, Color.red);

        //Draws right ray same way
        rightRay = Physics2D.Raycast(transform.localPosition + new Vector3(transform.localScale.x, 0, 0), Vector2.up, transform.localScale.y, LayerMask.GetMask("String Point"));
        Debug.DrawRay(transform.localPosition + new Vector3(transform.localScale.x, 0, 0), Vector2.up * transform.localScale.y, Color.red);


        if (topRay)
        {
            stringPointIntersectedWith = Int16.Parse(topRay.transform.name);
            isDead = true;
            Debug.Log("topray");
        }
        else if (bottomRay)
        {
            stringPointIntersectedWith = Int16.Parse(bottomRay.transform.name);
            isDead = true;
            Debug.Log("bottomRay");

        }
        else if (leftRay)
        {
            stringPointIntersectedWith = Int16.Parse(leftRay.transform.name);
            isDead = true;
            Debug.Log("leftRay");

        }
        else if (rightRay)
        {
            stringPointIntersectedWith = Int16.Parse(rightRay.transform.name);
            isDead = true;
            Debug.Log("rightRay");

        }
    }
}
