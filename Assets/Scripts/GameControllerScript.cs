using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

    string currentSceneName = "";
    float timeSpent;
    public string timeString;

    public int collectables = 0;
    public int collectablesAvailable = 0;

    public bool levelComplete = false;
    public bool isPlayerSphere = false;

    public GameObject winCanvas;
    public GameObject hudCanvas;

    // We give the controller the level order here, so we can go to it.
    public string[] LevelO = new string[]
    {
        "Tutorial", "LevelOne", "LevelTwo"
    };
    

    public void GameWin()
    {
        if (!levelComplete)
        {
            levelComplete = true;

            GameObject[] _players = GameObject.FindGameObjectsWithTag("Player");

            // Disable controls for all player objects.
            foreach (GameObject _player in _players)
            {
                _player.GetComponent<PlayerController>().playerInControl = false;
            }

            Instantiate(winCanvas);

        }
    }

    public void NextLevel()
    {

        // The current level is not in the level order, so we just head to the first one.
        if (!LevelO.Contains(currentSceneName))
        {
            ChangeScene(LevelO[0]);
        }
        else
        {
            for (int i = 0; i < LevelO.Length; i++)
            {
                // Win the game if you are on the final level.
                if ( i + 1 == LevelO.Length )
                {
                    GameWin();
                    return;
                }
                else
                {
                    // Look for the level we are on, and go to the next one.
                    if ( LevelO[i] == currentSceneName )
                    {
                        ChangeScene(LevelO[i+1]);
                        return;
                    }
                }
            }
        }

    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Debug.Log("Attempting to go to scene: " + scene);
    }


    
    // This is ran when the scene changes.
    void SceneChanged()
    {
        // Init all these variables because the scene has changed.
        // We don't need to know anything about the collectables, just how many there are.
        collectables = 0;
        collectablesAvailable = GameObject.FindGameObjectsWithTag("Collectable").Length;
        currentSceneName = SceneManager.GetActiveScene().name;
        levelComplete = false;
        timeSpent = 0f;
        timeString = "0:00";

        if ( currentSceneName != "MainMenu" && GameObject.FindGameObjectsWithTag("HUD").Length == 0 )
        {
            Instantiate(hudCanvas);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        // We want to use this Game Controller, so we don't want to remove it.
        DontDestroyOnLoad(this.gameObject);
        

        // Run this to initialize any variables.
        SceneChanged();
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelComplete)
        {
            timeSpent += Time.deltaTime;
        }

        // We are making the string here, and the HUD will grab it from the Game Controller.
        timeString = Mathf.Floor( timeSpent / 60 ).ToString() + ":" + Mathf.Floor( timeSpent % 60 ).ToString().PadLeft(2,'0');

    }

    // These are used to keep track when the scene changes.
    // ============================================================
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneChanged();
    }
    // ============================================================

}
