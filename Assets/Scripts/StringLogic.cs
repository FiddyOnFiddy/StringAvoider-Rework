using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringLogic : MonoBehaviour
{
    [SerializeField] int stringResolution;
    [SerializeField] float segmentLength = 0.025f;
    [SerializeField] float radius = 0.1f;

    [SerializeField] Vector2 mousePosition, previousMousePosition, mouseDelta;
    [SerializeField] Vector2 headPosition;

    float radians;

    [SerializeField] GameObject stringPointPrefab;
    [SerializeField] List<GameObject> stringPointsList;

    [SerializeField] Transform spawnPoint;
    

    // Start is called before the first frame update
    void Awake()
    {
        stringPointsList = new List<GameObject>();

        for (int i = 0; i < stringResolution; i++)
        {
            radians = 12 * Mathf.PI * i / stringResolution + Mathf.PI / 4;

            Vector2 stringPointPosition = new Vector2((spawnPoint.position.x + radius * Mathf.Cos(radians)), spawnPoint.position.y + radius * Mathf.Sin(radians));

            stringPointsList.Add(Instantiate(stringPointPrefab, stringPointPosition, Quaternion.identity, this.transform));
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
