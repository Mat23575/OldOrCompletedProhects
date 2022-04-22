using System.Collections;
using UnityEngine;

public class EvilRandom : AI
{
    public override bool choice(bool lastUserInput, bool lastNotUserInput)
    {
        if(Random.Range(0,100) % 3 == 0)
        {
            return true;
        }
        return false;
    }
}
