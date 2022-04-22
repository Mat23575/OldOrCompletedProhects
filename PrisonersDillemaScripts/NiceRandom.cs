using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class NiceRandom : AI
{
    public override bool choice(bool lastUserInput, bool lastNotUserInput)
    {
        if(Random.Range(0,100) % 3 == 0)
        {
            return false;
        }
        return true;
    }
}
