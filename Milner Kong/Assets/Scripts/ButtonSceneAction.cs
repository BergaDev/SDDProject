using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// The point of this script is to make the button actually do something upon click, this is adjustable in each button use as so to reuse the same script
public class ButtonSceneAction : MonoBehaviour
{
    public static int Difficulty = 0;
    public void Easy(){
        Difficulty = (Difficulty + 1);
    }
    
    public void Medium(){
        Difficulty = (Difficulty + 2);
    }

   public void Hard(){
        Difficulty = (Difficulty +3);
        Debug.Log("Hard Worked" + Difficulty);
    }
    //Make void public to show in editor options!!!!! UGHHHH so much time wasted 
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //Leave this as sceneName as to change per button in object menu in unity UI
    }
}
/*  */