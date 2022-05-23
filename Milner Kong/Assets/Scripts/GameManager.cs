using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private int level = 4;
    //Update this number with the first level of the game from build order, this fixes the infinte loop that can occur when loading the LoadFirst scene
    
    public static int lives;
    private int score;
    
    public int Round = 0;

   // public float timer = 0.0f;
   // public int seconds = 0;
    public float timer = 0.0f;
    public static int timecheck = 0;

   
    
   // public Timer script;
    private void Start()
    {
        
        DontDestroyOnLoad(gameObject);
        NewGame();
        
        Debug.Log("Initalised correctly");
    }
    void Update()
    {
        timer += Time.deltaTime;
        timecheck = (int) timer;
        //int seconds = timer % 60;
        //Debug.Log("Time is " + timecheck);
        //Used for testing that time is actually counting
    }

    private void NewGame()
    {
        lives = 3;
        score = 0;
        Round = 1;
        

        LoadLevel(3);
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
        lives = lives - 1;
// Extra timechecking here to correct for bug where game would loose 2 lives instead of one on death
    if (lives == 0) {

            if (timecheck <= 4){
                TimeLOL();
            } 
            else {
                LoadLevel(7);
                Debug.Log("Subprogram Test, sending to DeathScene");
            }
            
            
        } 
        else if (timecheck>=4){
            timer = 0.0f;
            LoadLevel(level);
            Debug.Log("Subprogram test, lives left = " + lives);
            
        }
    }
    public void DestroyObjects()
    {
        Destroy (GameObject.FindWithTag("PublicVar"));
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

    public void TimeLOL()
    {
        Debug.Log("Error caught, corrected");
        lives = lives + 1;

        //Double lives lost corrected
    }
    /*
    public void EnsureOneHit()
    {
        if 
    }
    */

   
}
