using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class byird : MonoBehaviour
{
    Rigidbody2D rgb2;
    public float distance2Pipe;
    [SerializeField]
    float boost;
    [SerializeField]
    LayerMask layer;
    public bool ispress;
    [SerializeField]
    bool isManual;
    float StartOperation;
    NeuralNet nn;
    private void Awake()
    {
        nn = NeuralNet.GetNet();
        print(nn);
        rgb2 = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        GetPipeDistance();
        if (isManual)
        {
            if (Input.GetKeyDown("space"))
            {
                rgb2.velocity = Vector2.zero;
                rgb2.AddForce(new Vector2(0, boost));
            }
        }
        else
        {
            pipes a = FindObjectOfType<pipes>();
            if (nn.ProcessData(a.bottomHeight,a.topHeight,distance2Pipe))
            {
                rgb2.velocity = Vector2.zero;
                rgb2.AddForce(new Vector2(0, boost));
            }
         
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "col")
        {
           
            DestroySelf();
        }

    }
    private void GetPipeDistance()
    {
        Ray2D r2d = new Ray2D(new Vector2(transform.position.x, transform.position.y), Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(r2d.origin, r2d.direction, 100000000000000000000000000000000000f, layer);
        Debug.DrawLine(transform.position, hit.point, Color.red);
        if (hit)
        {
            distance2Pipe = Mathf.Abs(transform.position.x - hit.transform.position.x);
        }
    }
    public void DestroySelf()
    {
        gameObject.SetActive(false);
        if (StartOperation > 0)
        {
            nn.gen.Lifetime = StartOperation - Time.time;
            StartOperation = -1;
        }
    }
    public void SetGen(Gene geen)
    {
        print(nn);
        nn.gen = geen;  //a nn está nula por algum motivo

        nn.gen.Lifetime = 0;
        StartOperation = Time.time;
    }
}
