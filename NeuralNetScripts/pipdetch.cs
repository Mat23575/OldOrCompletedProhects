using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipdetch : MonoBehaviour
{
    
    pipes pii;
    public bool istopdec;
    private void Start()
    {
        pii = FindObjectOfType<pipes>();
    }
    private void Update()
    {
        if(istopdec)
        {
            if(pii.topipex<transform.position.x)
            {
                pii.topipex = transform.position.x;
                pii.topHeight = transform.position.y;
            }
        }else if (pii.bottompipex<transform.position.x)
        {
            pii.bottompipex = transform.position.x;
            pii.bottomHeight = transform.position.y;
        }
    }
}
