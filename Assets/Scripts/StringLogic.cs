using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class StringLogic : MonoBehaviour
{
    [SerializeField] int noOfSegments;
    [SerializeField] float segmentLength = 0.025f;
    [SerializeField] float radius = 0.1f;

    [SerializeField] Vector2 mousePosition, previousMousePosition, mouseDelta;
    [SerializeField] float mouseSensitivity; 

    float radians;

    [SerializeField] GameObject stringPointPrefab;
    [SerializeField] List<GameObject> stringPointsGO;
    [SerializeField] List<Rigidbody2D> stringPointsRB;
    [SerializeField] List<Vector2> stringPointsData;

    [SerializeField] Transform spawnPoint;

    [SerializeField] bool isMouseDown;

    void Awake()
    {
        stringPointsGO = new List<GameObject>();
        stringPointsRB = new List<Rigidbody2D>();
        stringPointsData = new List<Vector2>();

        for (int i = 0; i < noOfSegments; i++)
        {
            radians = 12 * Mathf.PI * i / noOfSegments + Mathf.PI / 4;

            stringPointsData.Add(new Vector2((spawnPoint.position.x + radius * Mathf.Cos(radians)), spawnPoint.position.y + radius * Mathf.Sin(radians)));

            stringPointsGO.Add(Instantiate(stringPointPrefab, stringPointsData[i], Quaternion.identity, this.transform));
            stringPointsRB.Add(stringPointsGO[i].GetComponent<Rigidbody2D>());
         }
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDelta = mousePosition - previousMousePosition;
        mouseDelta *= mouseSensitivity;

        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
            previousMousePosition = mousePosition;
            mouseDelta = Vector2.zero; 
        }

        if (Input.GetMouseButton(0) && isMouseDown)
        {
            previousMousePosition = mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }
    }

    void FixedUpdate()
    {
        if(isMouseDown)
        {
            MoveString(mouseDelta.x, mouseDelta.y);
        }
    }

    void MoveString(float x, float y)
    {
        stringPointsData[0] = new Vector2(x + stringPointsData[0].x, y + stringPointsData[0].y);
        stringPointsRB[0].MovePosition(stringPointsData[0]);

        for (int i = 1; i < noOfSegments ; i++)
        {
            float nodeAngle = Mathf.Atan2(stringPointsData[i].y - stringPointsData[i - 1].y, stringPointsData[i].x - stringPointsData[i - 1].x);

            stringPointsData[i] = new Vector2(stringPointsData[i - 1].x + segmentLength * Mathf.Cos(nodeAngle), stringPointsData[i - 1].y + segmentLength * Mathf.Sin(nodeAngle));
            stringPointsRB[i].MovePosition(stringPointsData[i]);
        }
    }
}
