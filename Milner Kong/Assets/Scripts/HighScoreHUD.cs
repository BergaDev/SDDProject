using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreHUD : MonoBehaviour
{
    public static int HighScoreDisplay = 0;
    public Text HighScoreDis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HighScoreDisplay = GameManager.highscore;
        HighScoreDis.text = HighScoreDisplay.ToString();
    }
}
