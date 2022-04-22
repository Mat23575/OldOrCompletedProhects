using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene
{
    public float[] gens;
    public int genCount;
    public float genMaxValue;
    public float Lifetime;
    public Gene(int _genCount, float _genMaxValue)
    {


        genCount = _genCount;
        genMaxValue = _genMaxValue;

        gens = new float[genCount];

        for (int i = 0; i < gens.Length; i++)
        {
            gens[i] = Random.Range(-genMaxValue, genMaxValue);
        }
        
    }
    public Gene(float maxValue, float[] values)
    {
        genMaxValue = maxValue;
        gens = values;
        genCount = gens.Length;
       
    }

    public void Mutate()
    {
        int genToMutate = Random.Range(0, genCount);
        gens[genToMutate] = Random.Range(-genMaxValue, genMaxValue);
        genToMutate = Random.Range(0, genCount);
        gens[genToMutate] = Random.Range(-genMaxValue, genMaxValue);
        genToMutate = Random.Range(0, genCount);
        gens[genToMutate] = Random.Range(-genMaxValue, genMaxValue);

    }
    public Gene GenerateOffspring()
    {
        Gene offspring = new Gene(genCount, genMaxValue);
        offspring.gens = gens;
        return offspring;
    }
    public Gene GenerateOffspringM(float chanceToMutate)
    {
        Gene offspring = new Gene(genCount, genMaxValue);
        offspring.gens = gens;
        if(Random.Range(0,100)<chanceToMutate)
        {
            offspring.Mutate();
            offspring.Mutate();
        }
        return offspring;
    }
   

}
