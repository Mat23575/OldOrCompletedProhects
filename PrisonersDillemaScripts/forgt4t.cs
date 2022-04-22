using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forgt4t : AI
{
    public bool cheatedLastTurn = false;

    [SerializeField]
    manager manage;

   

    public override bool choice(bool lastUserInput, bool lastNotUserInput)
    {
        if(manage.is1stturn == true)
        {
            print("true");
            return true;
        } else if (lastNotUserInput == true)
        {
            cheatedLastTurn = false;
            print("true1");
            return true;
        } else if (cheatedLastTurn == false )
        {
            cheatedLastTurn = true;
            print("true2");
            return true;
        } else
        {
            print("false");
            return false;    
            
        }

    }
}
