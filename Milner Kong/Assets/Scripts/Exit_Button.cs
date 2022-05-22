using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Button : MonoBehaviour
{
    public void button_exit()
    {
        Application.Quit();
        //Only works in runtime not in editor, works as simple as written
    }
}
