using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsHUD : MonoBehaviour
{
    public static int PointsCount = 0;
    public Text PointsDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PointsCount = GameManager.gamescore;
        PointsDisplay.text = PointsCount.ToString();
    }
}
//How points or any varible is displayed in a text box, this is the script that is copy pasted across game