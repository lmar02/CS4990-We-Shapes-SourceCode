using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxController : MonoBehaviour
{

    GameObject playerChild;
    bool isPlayerSphere = false;
    AudioSource powerUpAudio;

    private void Start()
    {
        powerUpAudio = GetComponent<AudioSource>();
    }


    //switches player to a cirle
    private void OnTriggerEnter(Collider other)
    {
       if (isPlayerSphere == false)
        {
            AudioSource.PlayClipAtPoint(powerUpAudio.clip, transform.position);
            other.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<SphereCollider>().enabled = true;

            Transform trans = other.transform;
            Transform childTrans = trans.Find("Shape - Cube");

            if (childTrans != null)
            {
                playerChild = childTrans.gameObject;
            }

            playerChild.GetComponent<MeshRenderer>().enabled = false;
            isPlayerSphere = true;
        }
    

        
    

    
    }
}

