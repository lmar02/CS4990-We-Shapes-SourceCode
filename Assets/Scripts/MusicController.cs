using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip intro;
    public AudioClip loop;

    private AudioSource introSource;
    private AudioSource loopSource;

    private bool musicHasIntro = false;
    private bool musicHasLoop = false;
    public bool musicIntroPlayed = false;
    public bool musicLoopPlayed = false;

    Transform cameraTransform;

    // Use this for initialization
    void Start () 
    {

        var _tempObject = GameObject.Find("Main Camera");

        if (_tempObject != null)
        {
            cameraTransform = _tempObject.transform;
            Debug.Log("Camera found and assigned.");
        }
        else
        {
            Debug.LogError("Unable to get the Camera!");
        }       

        introSource = gameObject.AddComponent<AudioSource>();
        loopSource = gameObject.AddComponent<AudioSource>();

        if (intro != null)
        {
            musicHasIntro = true;
            introSource.clip = intro;
            introSource.Play();
            introSource.Pause();
            introSource.volume = 0.7f;
        }

        if (loop != null)
        {
            musicHasLoop = true;
            loopSource.clip = loop;
            loopSource.Play();
            loopSource.Pause();
            loopSource.volume = 0.7f;
        }

	}
	
	// Update is called once per frame
	void Update () 
    {

        this.transform.position = cameraTransform.position;

        if (musicIntroPlayed)
        {
            if (musicHasLoop)
            {
                if (!musicLoopPlayed)
                {
                    if (!introSource.isPlaying)
                    {
                        musicLoopPlayed = true;
                        loopSource.Play();
                        loopSource.loop = true;
                    }
                    else
                    {
                        if (introSource.time >= intro.length - .025)
                        {
                            musicLoopPlayed = true;
                            loopSource.Play();
                            loopSource.loop = true;
                        }
                    }
                }
            }
        }
        else
        {
            if (musicHasIntro)
            {
                musicIntroPlayed = true;
                introSource.Play();
            }
            else
            {
                if (musicHasLoop)
                {
                    musicLoopPlayed = true;
                    loopSource.Play();
                    loopSource.loop = true;
                }
            }
        }

    }
}
