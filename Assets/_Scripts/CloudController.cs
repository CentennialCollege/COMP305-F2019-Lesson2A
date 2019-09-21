using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class CloudController : MonoBehaviour
{
    [SerializeField]
    public Boundary boundary;

    [SerializeField]
    public Speed verticalSpeedRange;

    [SerializeField]
    public Speed horizontalSpeedRange;

    public float cloudStartOffset;

    public float verticalSpeed;
    public float horizontalSpeed;

    // Start is called before the first frame update
    void Start()
    {

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
        verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);

        float randomXPosition = Random.Range(boundary.LeftBounds, boundary.RightBounds);

        transform.position = new Vector2(randomXPosition, Random.Range(boundary.TopBounds, boundary.TopBounds + cloudStartOffset));

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
        currentPosition -= new Vector2(horizontalSpeed, verticalSpeed);
        transform.position = currentPosition;
    }
}
