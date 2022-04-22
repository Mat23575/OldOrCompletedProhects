using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pavlov : AI
{
    public override bool choice(bool lastUserInput, bool lastNotUserInput)
    {
        if(FindObjectOfType<manager>().is1stturn)
        {
            return true;
        } else if(lastNotUserInput)
        {
            return lastUserInput;
        } else
        {
            return !lastUserInput;
        }
    }
}
