using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : AI
{
    public override bool choice(bool lastUserInput, bool lastNotUserInput)
    {
        int i = Random.Range(0,100);
        if(i % 2 == 0)
        {
            return true;
        }
        return false;
    }
}

