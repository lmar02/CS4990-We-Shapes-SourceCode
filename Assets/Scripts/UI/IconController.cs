using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconController : MonoBehaviour
{

    public Sprite iconEmpty;
    public Sprite iconFull;

    Image currentImage;

    public int index;

    GameControllerScript gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        currentImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( gameController.collectables > index )
        {
            currentImage.sprite = iconFull;
        }
    }
}
