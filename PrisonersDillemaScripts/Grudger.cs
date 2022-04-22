using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grudger : AI
{
    [SerializeField]
    manager manage;

 public   bool hasCheated = false;

    public override bool choice(bool lastUserInput, bool lastNotUserInput)
    {
        if(manage.is1stturn)
        {
            
            return true;
            
        } else if (lastNotUserInput == false)
        {
            hasCheated = true;
        }
        

        if (!hasCheated)
        {
           
            return true;
        } else
        {
            return false;
        }
        
    }

    
}
