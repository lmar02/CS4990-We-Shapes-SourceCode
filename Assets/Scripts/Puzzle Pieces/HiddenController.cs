using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenController : MonoBehaviour
{

    public GameObject collectable;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Bring object into existance when the collectable is gone
        if (collectable == null)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
