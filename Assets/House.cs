using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool isConditionMet(float a, float b){
        if ((a >= requiredWood) && (b >= requiredSteel)) {
            return true;
        } else {
            return false;
        }
    }
}
