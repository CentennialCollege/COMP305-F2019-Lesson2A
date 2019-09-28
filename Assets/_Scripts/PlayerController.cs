using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
    public Speed speed;
    public Boundary boundary;

    public GameController gameController;


    // private variables
    private AudioSource thunderSound;
    private AudioSource yaySound;

    // Start is called before the first frame update
    void Start()
    {


        thunderSound = gameController.audioSources[(int)SoundClip.THUNDER];
        yaySound = gameController.audioSources[(int)SoundClip.YAY];
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "Cloud":
                thunderSound.Play();
                gameController.Lives -= 1;

                break;
            case "Island":
                yaySound.Play();
                gameController.Score += 100;

                break;
        }
    }
}
