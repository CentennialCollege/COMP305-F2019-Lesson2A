using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        [Header("Scoreboard")]
        [SerializeField]
        private int _score;
        public Text scoreLabel;

        [SerializeField]
        private int _lives;
        public Text livesLabel;

        // PUBLIC Properties
        public int Score { 
            get
            {
                return _score;
            }

            set
            {
                _score = value;
                scoreLabel.text = "Score: " + _score.ToString();
            }
        }

        public int Lives {
            get
            {
                return _lives;
            }

            set
            {
                _lives = value;
                if(_lives <= 0)
                {
                    SceneManager.LoadScene("End");
                }
                livesLabel.text = "Lives: " + _lives.ToString();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            Lives = 5;
            Score = 0;


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
