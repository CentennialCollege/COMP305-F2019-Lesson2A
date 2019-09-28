using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util { 
    [System.Serializable]
    public class GameController : MonoBehaviour
    {
        [Header("Scene Game Objects")]
        public GameObject cloud;
        public GameObject island;

        [Header("Cloud Control")]
        public int NumberOfClouds;
        public List<GameObject> clouds;

        [Header("Audio Sources")]
        public SoundClip defaultSoundClip;
        public AudioSource[] audioSources;

        // Start is called before the first frame update
        void Start()
        {

            if((defaultSoundClip != SoundClip.NONE) && (defaultSoundClip != SoundClip.NUMBER_OF_CLIPS))
            {
                AudioSource defaultClip = audioSources[(int)defaultSoundClip];
                defaultClip.playOnAwake = true;
                defaultClip.loop = true;
                defaultClip.Play();
            }
  
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
}
