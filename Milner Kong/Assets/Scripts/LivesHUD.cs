using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesHUD : MonoBehaviour
{
   public static int OtherLives = 0;
    public Text LivesTest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        OtherLives = GameManager.lives;
        LivesTest.text = OtherLives.ToString();
    }
}
