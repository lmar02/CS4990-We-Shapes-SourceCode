using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{

    Text textTime;
    GameControllerScript gameController;
    public GameObject collectableImage;

    // Start is called before the first frame update
    void Start()
    {
        textTime = GameObject.Find("TimeText").GetComponent<Text>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();

        for (int i = 0; i < gameController.collectablesAvailable; i++)
        {
            GameObject temp = Instantiate(collectableImage);
            temp.transform.SetParent (GameObject.FindGameObjectWithTag("HUD").transform, false);
            temp.GetComponent<IconController>().index = i;
            temp.GetComponent<RectTransform>().anchoredPosition = new Vector3( (40 + ( 73 * (i) ) ), -100, 0 ) ;
        }

    }

    // Update is called once per frame
    void Update()
    {
        textTime.text = gameController.timeString;
    }
}
