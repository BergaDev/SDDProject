using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDifficulty : MonoBehaviour
{
    // Start is called before the first frame update
    public int Difficulty = 0;

    void Easy(){
        Difficulty = (Difficulty + 1);
    }
    
    void Medium(){
        Difficulty = (Difficulty + 2);
    }

    void Hard(){
        Difficulty = (Difficulty +3);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
