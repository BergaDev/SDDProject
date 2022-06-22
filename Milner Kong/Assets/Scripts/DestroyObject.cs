using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       DestroyObjects(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyObjects()
    {
        Destroy (GameObject.FindWithTag("PublicVar"));
    }
}
// Makes sure that on death screen you do not have two instances of gamemanger running
//This prevents another instance of double death 
