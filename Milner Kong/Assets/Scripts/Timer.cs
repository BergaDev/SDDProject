using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //int seconds = timer % 60;
        //Debug.Log("Time is " + timer);
    }
}
