using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerCheck : MonoBehaviour
{

    public GameObject GameController;
    

    // Start is called before the first frame update
    void Awake()
    {
        if ( GameObject.FindGameObjectsWithTag("GameController").Length == 0 )
        {
            Instantiate(GameController);
        }
    }

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
