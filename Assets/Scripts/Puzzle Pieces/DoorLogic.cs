using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{

    public GameObject target;

    public int targetAmount = 0;

    private bool singleTarget = true;
    private GameControllerScript gameController;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null || targetAmount != 0)
        {
            singleTarget = false;
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if we are looking for a specific collectable, otherwise look for all.
        if (singleTarget)
        {
            if (target == null)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (targetAmount != 0)
            {
                if (gameController.collectables == targetAmount)
                {
                    Destroy(gameObject);
                }
            }
            else
            if (gameController.collectables == gameController.collectablesAvailable)
            {
                Destroy(gameObject);
            }
        }
    }
}
