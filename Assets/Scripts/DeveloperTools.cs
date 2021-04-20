using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeveloperTools : MonoBehaviour
{
    private string currentScene;
    StringDeathScript stringDeathScript;
    StringMovement stringMovementScript;

    // Start is called before the first frame update
    void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
        stringDeathScript = GameObject.FindObjectOfType<StringDeathScript>();
        stringMovementScript = GameObject.FindObjectOfType<StringMovement>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(currentScene);

    }
}
