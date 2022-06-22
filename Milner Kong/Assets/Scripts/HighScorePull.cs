using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScorePull : MonoBehaviour
{
    public static int HighScoreSaved = 0;
    public Text HighScorePlayerDisplay;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.GetInt();
    }

    // Update is called once per frame
    void Update()
    {
        HighScoreSaved = PlayerPrefs.GetInt("HighScoreSave");
        HighScorePlayerDisplay.text = HighScoreSaved.ToString();
    }
}
