using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t4t : AI
{
    [SerializeField]
    manager manage;

    public override bool choice(bool lastUserInput, bool lastNotUserInput)
    {
        if(manage.is1stturn)
        {
            print("true");
            return true;
        } else
        {
            print("idk");
            return lastNotUserInput;
        }
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
