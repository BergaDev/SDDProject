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
        PointsCount = GameManager.score;
        PointsDisplay.text = PointsCount.ToString();
    }
}
