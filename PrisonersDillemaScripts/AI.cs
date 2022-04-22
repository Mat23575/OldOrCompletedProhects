using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AI : MonoBehaviour
{

    public abstract bool choice( bool lastUserInput, bool lastNotUserInput);
 
}
