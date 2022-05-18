using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// The point of this script is to make the button actually do something upon click, this is adjustable in each button use as so to reuse the same script
public class ButtonSceneAction : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //Leave this as sceneName as to change per button in object menu in unity UI
    }
}
/*  */