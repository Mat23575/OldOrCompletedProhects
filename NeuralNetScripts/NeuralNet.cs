using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Node
{
    public float value;
    public float bias;
    public Node(float b)
    {
        value = 1;
        bias = b;
    }
}
public class Link 
{
    public Node first, second;
    public float linkf;
    public Link(Node a,Node b, float linkFactor)
    {
        first = a;
        second = b;
        linkf = linkFactor;
    }
    public void TransmitInfo(bool isf)
    {
       
        if (isf || first.bias < first.value)
        {
            second.value += linkf;
        }
        


    }
}

 class NeuralNet
{
    private static NeuralNet net = null;

    public static NeuralNet GetNet()
    {
        if(net == null)
        {
            net = new NeuralNet();
        }
        Debug.Log(net.inNod);
        return net;
    }
    private NeuralNet ()
    {

        inNode = new Node[inNod];
        midNode = new Node[midNod];
        mid2node = new Node[mid2Nod];
        outNode = new Node[outNod];

        gen = new Gene(49, 10); //49 é o total de genes usados

        for (int i = 0; i < inNode.Length; i++)
        {
            inNode[i] = new Node(Mathf.Abs(gen.gens[i]));
        }
        for (int i = 0; i < midNode.Length; i++)
        {
            midNode[i] = new Node(Mathf.Abs(gen.gens[i + inNod]));
        }
        for (int i = 0; i < mid2node.Length; i++)
        {
            mid2node[i] = new Node(Mathf.Abs(gen.gens[i + inNod + midNod]));
        }
        for (int i = 0; i < outNode.Length; i++)
        {
            outNode[i] = new Node(Mathf.Abs(gen.gens[i + inNod + midNod + mid2Nod]));

        }

        foreach (Node nod in inNode)
        {

            foreach (Node no in midNode)
            {
                Link l = new Link(nod, no, 1f);
                aLink.Add(l);
                allLinks.Add(l);
            }
        }
        foreach (Node nod in midNode)
        {
            foreach (Node no in mid2node)
            {
                Link l = new Link(nod, no, 1f);
                blink.Add(l);
                allLinks.Add(l);
            }
        }
        foreach (Node nod in mid2node)
        {
            foreach (Node no in outNode)
            {
                Link l = new Link(nod, no, 1f);
                clink.Add(l);
                allLinks.Add(l);
            }
        }

        for (int i = 0; i < allLinks.Count; i++)
        {
            allLinks[i].linkf = gen.gens[i + inNode.Length + mid2node.Length + midNode.Length + outNode.Length];
        }
    }

    Node[] inNode, midNode,mid2node, outNode;
    [SerializeField]
    int inNod = 3;
    int midNod = 4;
    int mid2Nod = 4; 
    int outNod = 2;
    List<Link> allLinks = new List<Link>();
    List<Link> aLink = new List<Link>();
    List<Link> blink = new List<Link>();
    List<Link> clink = new List<Link>();
    public Gene gen = null;

   

    public bool ProcessData(float val01, float val02, float val03) { 
        inNode[0].value = val01;
        inNode[1].value = val02;
        inNode[2].value = val03;
        foreach (Link a in aLink)
        {
            a.TransmitInfo(true);
        }
        foreach (Link a in blink)
        {
            a.TransmitInfo(false);
        }
        foreach (Link a in clink)
        {
            a.TransmitInfo(false);
        }
        if (outNode[0].value > outNode[1].value)
        {
            return true;
        }
        return false;
    }

    
    
   
}
