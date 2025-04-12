using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCapper : MonoBehaviour
{
    public int targetFPS = 60;
    private void Awake() 
    { 
        Application.targetFrameRate = targetFPS; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
