using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatoform : MonoBehaviour
{

    MeshRenderer mesh;
    BoxCollider coll;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        coll = GetComponent<BoxCollider>();
        
    }
    // diappears when player walks on it
    private void OnTriggerEnter(Collider other)
    {
        mesh.enabled = false;
        coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
