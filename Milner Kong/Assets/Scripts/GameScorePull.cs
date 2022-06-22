using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScorePull : MonoBehaviour
{
    public static int GameScoreSaved = 0;
    public Text GameScorePlayerDisplay;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.GetInt();
    }

    // Update is called once per frame
    void Update()
    {
        GameScoreSaved = PlayerPrefs.GetInt("GameScoreSave");
        GameScorePlayerDisplay.text = GameScoreSaved.ToString();
    }
}
