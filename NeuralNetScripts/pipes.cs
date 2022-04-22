using System.Collections.Generic;
using UnityEngine;


public class pipes : MonoBehaviour
{
    [SerializeField]
    GameObject pipea, pipeEnd, col, pipeDetector;
    float timePassed;
    [SerializeField]
    int pipeInterval;
    List<GameObject> PipeCol = new List<GameObject>();
    
    
    public float topHeight, bottomHeight,topipex,bottompipex;

    // Start is called before the first frame update
    void Start()
    {
        topHeight = -5000f;
        bottomHeight = -5000f;
        
        timePassed = 0;
        genPipes();
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= pipeInterval)
        {
            timePassed -= pipeInterval;
            genPipes();
        }
       
        
    }
    private void genPipes()
    {
        //4.5,-4.5
        //length10
        int height = Random.Range(-1, 5);
       
        PipeCol.Add(Instantiate(col, new Vector3(10f, 0f, 0f), Quaternion.identity));
        if (height == -1)
        {
            for (float i = 0; i < 6; i++)
            {
                PipeCol.Add(Instantiate(pipea, new Vector3(10, i - 4.5f, 0), Quaternion.identity));
            }
            PipeCol.Add(Instantiate(pipeEnd, new Vector3(10f, 1.5f, 0f), Quaternion.identity));
             Instantiate(pipeDetector, new Vector3(10f, 2f, 0f), Quaternion.identity).GetComponent<pipdetch>().istopdec = false;
            
            Instantiate(pipeDetector, new Vector3(10f, 5f, 0f), Quaternion.identity).GetComponent<pipdetch>().istopdec = true;
        }
        else if (height == 5)
        {
            for (float i = 0; i < 6; i++)
            {
                PipeCol.Add(Instantiate(pipea, new Vector3(10, i - 0.5f, 0), Quaternion.identity));

            }
            PipeCol.Add(Instantiate(pipeEnd, new Vector3(10f, -1.5f, 0f), Quaternion.identity));
            Instantiate(pipeDetector, new Vector3(10f, -2f, 0f), Quaternion.identity).GetComponent<pipdetch>().istopdec = true;
            Instantiate(pipeDetector, new Vector3(10f, -5f, 0f), Quaternion.identity).GetComponent<pipdetch>().istopdec = false;
        }
        else
        {
            int minus = 5 - height;
            for (int i = 0; i < height; i++)
            {
                PipeCol.Add(Instantiate(pipea, new Vector3(10f, i - 4.5f, 0), Quaternion.identity));
            }
            PipeCol.Add(Instantiate(pipeEnd, new Vector3(10f, height - 4.5f, 0f), Quaternion.identity));
            Instantiate(pipeDetector, new Vector3(10f, height - 4f, 0f), Quaternion.identity).GetComponent<pipdetch>().istopdec = false;

            for (int i = -minus; i < 0; i++)
            {
                PipeCol.Add(Instantiate(pipea, new Vector3(10f, i + 5.5f, 0), Quaternion.identity));
            }
            PipeCol.Add(Instantiate(pipeEnd, new Vector3(10f, -minus + 4.5f, 0f), Quaternion.identity));
            Instantiate(pipeDetector, new Vector3(10f, -minus + 4f, 0f), Quaternion.identity).GetComponent<pipdetch>().istopdec = true;
        }
    }
}
