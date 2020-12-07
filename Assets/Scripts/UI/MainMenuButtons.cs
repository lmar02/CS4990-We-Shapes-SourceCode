using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    private GameControllerScript gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    // Start is called before the first frame update
    public void StartGame(string sceneName)
    {
        gameController.NextLevel();
    }

    public void ShowControls()
    {
        // TODO: Implement.
        // if not shown, disable menu stuff, show controls, vice versa
    }

    public void MainMenu()
    {
        Debug.Log("Attempting to go to main menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Ending the game.");
        Application.Quit();
    }

}
