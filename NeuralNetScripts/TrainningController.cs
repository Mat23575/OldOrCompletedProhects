using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TrainningController: MonoBehaviour {

    [SerializeField]
    float trainningDuration;
    [SerializeField]
    int trainningCicles;
    int cicle;
    public float cicleStart;
    [SerializeField]
    int population;
    [SerializeField]
    float durationIncrement,incLimit;
    [SerializeField]
    pipes abcdef;
    [Space(10)]
    [SerializeField]
    PoolingSystem pooling;
    [SerializeField]
    int poolIndex;
    bool d = false;
    List<Gene> genes;
    List<byird> enemies;

    bool canRun = false;

    void Start() {
        cicle = 0;
        if (!pooling || poolIndex < 0
            || trainningCicles < 0 || trainningDuration < 0)
            gameObject.SetActive(false);
        genes = new List<Gene>();
        enemies = new List<byird>();
        Invoke("StartTraining", 0.5f);
    }
    
    public void StartTraining() {
        abcdef.gameObject.SetActive(true);
        if(trainningDuration >= incLimit)
        {
            trainningDuration += durationIncrement;
        }
        canRun = true;
        foreach (byird e in enemies)
            e.DestroySelf();
        enemies.Clear();
        cicleStart = Time.time;
        cicle++;
        if (cicle > trainningCicles) {
            canRun = false;
            return;
        }
        if(genes.Count < population) {
            int j = population - genes.Count;
            for (int i = 0; i < j; i++) {
                print("nevGen");
                genes.Add(new Gene(49, 1f)); //49 é o total de genes usados
            }
        }
        for(int i = 0; i < population; i++) {
            byird enemy = pooling.InstantiateFromPool(
                poolIndex, transform.position,
                Quaternion.identity).
                GetComponent<byird>();
            print(genes.Count);
            print(genes[i].genCount);
            enemy.SetGen(genes[i]); 
            enemies.Add(enemy);
        }
    }

    public void EndTrainingCicle() {
        d = true;
        print(":)");
        foreach (byird e in enemies)
            e.DestroySelf();
        List<Gene> ordered = genes.OrderBy(
            x => x.Lifetime).ToList();
        List<Gene> nextGeneration = new List<Gene>();

        if (cicle >= trainningCicles) {
            canRun = false;
            return;
        }

        int i = ordered.Count - 1;
        while (nextGeneration.Count < population && i > 1) {
            nextGeneration.Add(ordered[i].GenerateOffspringM(100f));
            nextGeneration.Add( ordered[i].GenerateOffspringM( 50f));
            nextGeneration.Add( ordered[i].GenerateOffspringM( 75f));
            i--;
        }

        genes = nextGeneration;
    }

    void CicleControl() {
        if(trainningDuration < Time.time - cicleStart) {
            if(!d)
            {
                EndTrainingCicle();
                abcdef.gameObject.SetActive(false);
                Invoke("StartTraining", 10f);
                Invoke("setd", 11f);
            }
           
        }
    }
    private void setd()
    {
        d = false;
    }
    private void Update() {
        if(canRun)
            CicleControl();
    }
}
