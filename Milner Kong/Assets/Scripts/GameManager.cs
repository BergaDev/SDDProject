using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private int level = 2;
    //Update this number with the first level of the game from build order, this fixes the infinte loop that can occur when loading the LoadFirst scene
    
    public static int lives;
    public static int score = 10000;
    public static int gamescore =1;
    public static int HighScoreSave = 0;
    public static int GameScoreSave = 0;
    public static int diffchosen;
    public int Round = 0;

   
    public float timer = 0.0f;
    public static int timecheck = 0;
	public static int highscore = 0;

   
    
 
    private void Start()
    {
        
        DontDestroyOnLoad(gameObject);
        diffchosen = (diffchosen + UniVar.UniDiff);
        //Remember order that this is executed in, hvaing diff at 0 on game start won't work properly
        NewGame();
        
        //Starting as soon as loadfirst scene is loaded, then movies on to first 
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        timecheck = (int) timer;
        gamescore = score - timecheck;
		// Updating multiple varibles that keep track of points/time across the game, some are here because for easier testing
		
        if (score <=0){
           score = score + 5;
            //SaveGame();
            //LoadLevel(6);
            //Time ran out, death, not using, breaks when loading a new game after death
        } 
        
		
		
        //Debug.Log("Time is " + timecheck);
        //Used for testing that time is actually counting
    }

    private void NewGame()
    {
        lives = 3;
        score = 0;
        Round = 1;
        // Setting variables to correct counts for game start
		
		if (diffchosen == 1){
			score = 1000;
		}
		else if (diffchosen == 2){
			score = 1250;
		}	
		else if (diffchosen == 3){
			score = 1500;
		}
        else if (diffchosen == 0){
            Debug.Log("You idiot");
        }
        //Setting/checking difficulty
		PlayerPrefs.DeleteKey("GameScoreSave");
        LoadLevel(2);
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
        //score += 1000;
        //Debug.Log("Points won" +score);
        //One level only now, not needed
        HighScoreCalc();
        GameFinishCalc();
        SaveGame();
        int nextLevel = level + 1;
		//Updates variable to load next level 

        if (nextLevel < SceneManager.sceneCountInBuildSettings) {
            LoadLevel(nextLevel);
        } else {
            LoadLevel(1);
        }
		//Loads next level
    }
	//Executes when player is hit
    public void LevelFailed()
    {
        lives = lives - 1;
        // Extra timechecking here to correct for bug where game would loose 2 lives instead of one on death
    if (lives == 0) {

            if (timecheck <= 4){
                TimeLOL();
				//Corrects for double death
            } 
            else {
                HighScoreCalc();
                GameFinishCalc();
                SaveGame();
                LoadLevel(4);
                //Update scene number when reordering scenes
                Debug.Log("Subprogram Test, sending to DeathScene");
            }
            
            
        } 
        else if (timecheck>=4){
            
            SaveGame();
            timer = 0.0f;
            LoadLevel(level);
            Debug.Log("Subprogram test, lives left = " + lives);
            HitCalc();            
        }
    }
    public void DestroyObjects()
    {
        Destroy (GameObject.FindWithTag("PublicVar"));
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("GameScoreSave", GameScoreSave);
        PlayerPrefs.SetInt("HighScoreSave", HighScoreSave);
       // PlayerPrefs.SetInt("lives", lives);
       //Saving scores on game end
    }

    public void LoadGame()
    {
        PlayerPrefs.GetInt("gamescore");
        PlayerPrefs.GetInt("highscore");
       // PlayerPrefs.GetInt("lives");
       //Loading scores on game start
    }

    public void TimeLOL()
    {
        Debug.Log("Error caught, corrected");
        lives = lives + 1;

        //Double lives lost corrected
    }

    public void HighScoreCalc()
    {
        if (gamescore >= highscore){
		highscore = gamescore;
		}
    }
    //Calculates gamescore on game end
    public void GameFinishCalc(){
        HighScoreSave = HighScoreSave + highscore;
        GameScoreSave = GameScoreSave + gamescore;
        //Calculates scores to save on game end 
    }

    public void HitCalc()
    {
         if (diffchosen == 1){
                score = (score - 100);
            }
            else if (diffchosen == 2){
                score = (score - 150);
            }
            else if (diffchosen == 3){
                score = (score - 200);
            }
    }
    //Calculating points to be taken when hit by barrel
    
   
}
