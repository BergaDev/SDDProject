using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniVar : MonoBehaviour
{
    public static int UniDiff = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(UniDiff);
    }

    // Update is called once per frame
    void Update()
    {
        UniDiff = ButtonSceneAction.Difficulty;
        
    }
}
