using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringDeathScript : MonoBehaviour
{
    StringMovement stringMovement;
    [SerializeField] bool gameOver;

    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        stringMovement = GetComponent<StringMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StringCollisionScript.IsDead && !gameOver)
        {
            stringMovement.CanMove = false;
            stringMovement.MoveRigidBodies = false;
            Debug.Log("dead: " + StringCollisionScript.StringPointIntersectedWith);
            gameOver = true;
        }
    }

}
