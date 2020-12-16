using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringDeathScript : MonoBehaviour
{
    StringMovement stringMovement;
    [SerializeField] bool gameOver;

    // Start is called before the first frame update
    void Awake()
    {
        stringMovement = GetComponent<StringMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(StringColliisionScript.IsDead && !gameOver)
        {
            stringMovement.CanMove = false;
            Debug.Log("dead: " + StringColliisionScript.StringPointIntersectedWith);
            gameOver = true;
        }
    }

    void GameOver()
    {
        
    }

}
