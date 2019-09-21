using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
    public Speed speed;
    public Boundary boundary;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();

    }

    private void Move()
    {
        Vector2 currentPosition = transform.position;

        if (Input.GetAxis("Horizontal") > 0)
        {
            currentPosition += new Vector2(speed.max, 0.0f);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            currentPosition += new Vector2(speed.min, 0.0f);
        }

        transform.position = currentPosition;
    }

    public void CheckBounds()
    {
        if(transform.position.x > boundary.RightBounds)
        {
            transform.position = new Vector2(boundary.RightBounds, transform.position.y);
        }

        if (transform.position.x < boundary.LeftBounds)
        {
            transform.position = new Vector2(boundary.LeftBounds, transform.position.y);
        }
    }
}
