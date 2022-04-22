using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{
    [SerializeField]
    bool isdetec;
    public float pipeSpeed;
    pipes pl;
    // Start is called before the first frame update
    void Start()
    {
        pl = FindObjectOfType<pipes>();
        pipeSpeed = 2.1f;
    }
    private void Update()
    {
        if(pl.enabled == false)
        {
            Destroy(gameObject);
        }
        transform.position -= new Vector3(pipeSpeed * Time.deltaTime, 0, 0);
        if(isdetec)
        {
            if(transform.position.x<-1)
            {
                pl.topipex = -100000;
                Destroy(gameObject);
            } 
        } else if (transform.position.x <-10)
        {
            Destroy(gameObject);
        }
       
    }
}
