using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagLogic : MonoBehaviour
{

    AudioSource nextLevelAudio;
    GameControllerScript gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        nextLevelAudio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        nextLevelAudio.Play();
        gameController.NextLevel();
    }
}
