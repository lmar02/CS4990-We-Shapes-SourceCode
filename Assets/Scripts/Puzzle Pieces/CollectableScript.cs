using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectableScript : MonoBehaviour
{

    private AudioSource audioS;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>().collectables += 1;
        AudioSource.PlayClipAtPoint(audioS.clip, transform.position);
        Destroy(gameObject);
    }

}
