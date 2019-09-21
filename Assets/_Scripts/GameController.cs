using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameController : MonoBehaviour
{
    [Header("Scene Game Objects")]
    public GameObject cloud;
    public GameObject island;

    public int NumberOfClouds;

    public List<GameObject> clouds;

    // Start is called before the first frame update
    void Start()
    {

        for (int cloudNum = 0; cloudNum < NumberOfClouds; cloudNum++)
        {
            clouds.Add(Instantiate(cloud));
        }

        Instantiate(island);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
