using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class IslandController : MonoBehaviour
{
    [SerializeField]
    public Boundary boundary;


    public float verticalSpeed = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        //boundary = new Boundary(); 

        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    void Reset()
    {
        float randomXPosition = Random.Range(boundary.LeftBounds, boundary.RightBounds);

        transform.position = new Vector2(randomXPosition, boundary.TopBounds);

    }

    void CheckBounds()
    {
        if (transform.position.y <= boundary.BottomBounds)
        {
            Reset();
        }
    }

    void Move()
    {
        Vector2 currentPosition = transform.position;
        currentPosition -= new Vector2(0.0f, verticalSpeed);
        transform.position = currentPosition;
    }
}
