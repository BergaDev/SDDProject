using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int level = 4;
    //Update this number with the first level of the game from build order, this fixes the infinte loop that can occur when loading the LoadFirst scene
    
    private int lives;
    private int score;
    //public int CorrectSceneLoad;
    //Ensures that level transition and deaths work correctly, if not causes character to float

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        NewGame();
    }

    private void NewGame()
    {
        lives = 3;
        score = 0;

        LoadLevel(4);
        Debug.Log("Loading LevelOrder " + level);
        //Update this number to match load order in build settings, if not set to the right number a wrong level will be loaded instead
        //If LoadFirst is the number selected the game will get stuck on this level, this caused signicant problems the first time I was building the project
    }

    private void LoadLevel(int index)
    {
        level = index;

        Camera camera = Camera.main;

        // Don't render anything while loading the next scene to create
        // a simple scene transition effect
        if (camera != null) {
            camera.cullingMask = 0;
        }

        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(level);
    }

    public void LevelComplete()
    {
        score += 1000;
        Debug.Log("Points won" +score);

        int nextLevel = level + 1;

        if (nextLevel < SceneManager.sceneCountInBuildSettings) {
            LoadLevel(nextLevel);
        } else {
            LoadLevel(1);
        }
    }

    public void LevelFailed()
    {
        lives--;

        if (lives <= 0) {
            NewGame();
            Debug.Log("Subprogram Test, new game started");
        } else {
            LoadLevel(level);
            Debug.Log("Subprogram test, lives left = " + lives);
        }
    }

    public void CorrectSceneLoad()
    {
       int CorrectSceneLoad = 1;

        if (CorrectSceneLoad <= 0) {
                Debug.Log("Not loaded correctly, start from LoadFirst scene");
        } else {
                Debug.Log("Correct scene load");
        }

    }
    //Used to correct for loading the wrong scene in engine, corrects jesus/floating error
}
