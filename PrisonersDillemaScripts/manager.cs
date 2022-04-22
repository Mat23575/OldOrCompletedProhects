using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class manager : MonoBehaviour
{

    int nOfRepeat;

    // Bunch of AI types I made
    [SerializeField]
    AI CHEAT, COOPERATE,T4T, GRUDGER, FT4T,PAVLOV,RANDOM,NRANDOM,ERANDOM;


    [SerializeField]
    Grudger g;

    [SerializeField]
    forgt4t f;

    
    [SerializeField]
    int StartnOfRepeat;


    [SerializeField]
    Text p1Pointstxt, p2Pointstxt;

    
    bool isp1Set = false;
    bool isp2Set = false;


    
    [SerializeField]
    int BetrayedPoints, BetrayerPoints, CooperatorPoints, CheaterPoints;
    
    //the AI for each "player"
    AI chosenAIp1;
    AI chosenAIp2;

    //useful for knowing when to use the variables of choice
    public bool is1stturn = true;

    //useful for the variables of choice
    bool lastP1choice;
    bool lastP2Choice;

    // the points of each AI
    int p1Points = 0;
    int p2Points = 0;

    //used for calculating the errors and chance of error
    int chanceOfMistake = 0;
    int randomRoll;
    int randomRollp2;


   

    // Start is called before the first frame update
    void Start()
    {
        nOfRepeat = StartnOfRepeat;
    }

  
   //bunch of functions for setting the AI type of each player
    public void AIp1Cheat()
    {
        chosenAIp1 = CHEAT;
        isp1Set = true;
    }

    public void AIp1Pavlov()
    {
        chosenAIp1 = PAVLOV;
        isp1Set = true;
    }

    public void AIp2Pavlov()
    {
        chosenAIp2 = PAVLOV;
        isp2Set = true;
    }

    public void AIp1Random()
    {
        chosenAIp1 = RANDOM;
        isp1Set = true;
    }
    public void AIp2Random()
    {
        chosenAIp2 = RANDOM;
        isp2Set = true;
    }

    public void AIp1NRandom()
    {
        chosenAIp1 = NRANDOM;
        isp1Set = true;
    }
    public void AIp2NRandom()
    {
        chosenAIp2 = NRANDOM;
        isp2Set = true;
    }
    public void AIp1ERandom()
    {
        chosenAIp1 = ERANDOM;
        isp1Set = true;
    }
    public void AIp2ERandom()
    {
        chosenAIp2 = ERANDOM;
        isp2Set = true;
    }
    public void AIp2Cheat()
    {
        chosenAIp2 = CHEAT;
        isp2Set = true;
    }

    public void AIp1coop()
    {
        chosenAIp1 = COOPERATE;
        isp1Set = true;
    }

    public void AIp2Coop()
    {
        chosenAIp2 = COOPERATE;
        isp2Set = true;
    }

    public void AIp1T4T()
    {
        chosenAIp1 = T4T;
        isp1Set = true;
    }

    public void AIp2T4T()
    {
        chosenAIp2 = T4T;
        isp2Set = true;
    }

    public void AIp1Grudger()
    {
        chosenAIp1 = GRUDGER;
        isp1Set = true;
    }
    public void AIp2Grudger()
    {
        chosenAIp2 = GRUDGER;
        isp2Set = true;
    }

    public void AIp1FT4T()
    {
        chosenAIp1 = FT4T;
        isp1Set = true;
    }

    public void AIp2FT4T()
    {
        chosenAIp2 = FT4T;
        isp2Set = true;
    }
  
 /* public void SetAI(AI choice, bool isp1)
    {
        if (isp1)
            chosenAIp1 = choice;
        else
            chosenAIp2 = choice;
    }*/

    //BIG function. it basically compares the output from each AI's choice function, adds up the points, and sets the lastP1/2Choice to their respective values, plus accounting for mistakes
    public void run()
    {
        print("boot");
        if (isp1Set && isp2Set)
        {
            print("both players set");
            g.hasCheated = false;
            f.cheatedLastTurn = false;
            for (int i = 0; i < nOfRepeat; i++)
            {

                randomRoll = Random.Range(0, 100);
                randomRollp2 = Random.Range(0, 100);
                print(randomRoll + "miss chancep1");
                print(randomRollp2 + "miss cahancep2");
                bool p1Choice1st = true;
                bool p2Choice1st = true;

                bool p1Choicenst = true;
                bool p2Choicenst = true;
                if(is1stturn)
                {
                    p1Choice1st = chosenAIp1.choice(true, true);
                    p2Choice1st = chosenAIp2.choice(true, true);
                } else
                {
                    p1Choicenst = chosenAIp1.choice(lastP1choice, lastP2Choice);
                    p2Choicenst = chosenAIp2.choice(lastP1choice, lastP2Choice);
                }

                
                if ((randomRoll > chanceOfMistake) && (randomRollp2 > chanceOfMistake))
                {
                    print("both players hit");
                    if (is1stturn)
                    {
                        print("firstTurn");
                        if (p1Choice1st && p2Choice1st)
                        {
                            p1Points = p1Points + CooperatorPoints;
                            p2Points = p2Points + CooperatorPoints;
                            print("0 , 0");
                            lastP1choice = true;
                            lastP2Choice = true;
                            print("ponitsAwarded");

                        }
                        else if (p1Choice1st && !p2Choice1st)
                        {
                            p1Points = p1Points + BetrayedPoints;
                            p2Points = p2Points + BetrayerPoints;
                            print("0 ,  1");
                            lastP1choice = true;
                            lastP2Choice = false;
                            print("pointsAwarded");

                        }
                        else if ((!p1Choice1st) && p2Choice1st)
                        {
                            p1Points = p1Points + BetrayerPoints;
                            p2Points = p2Points + BetrayedPoints;
                            print("1 , 0");
                            lastP1choice = false;
                            lastP2Choice = true;
                            print("pointsAwarded");
                        }
                        else if (!(p1Choice1st ||p2Choice1st))
                        {
                            p1Points = p1Points + CheaterPoints;
                            p2Points = p2Points + CheaterPoints;
                            print("1  ,  1");
                            lastP1choice = false;
                            lastP2Choice = false;
                            print("pointsAwarded");

                        }
                        is1stturn = false;
                    }
                    else
                    {
                        print("notFirstTurn");
                        if (p1Choicenst && p2Choicenst)
                        {
                            p1Points = p1Points + CooperatorPoints;
                            p2Points = p2Points + CooperatorPoints;
                            print("0 , 0");
                            lastP1choice = true;
                            lastP2Choice = true;
                            print("pointsAwarded");
                        }
                        else if (p1Choicenst && !p2Choicenst)
                        {
                            p1Points = p1Points + BetrayedPoints;
                            p2Points = p2Points + BetrayerPoints;
                            print("0 ,  1");
                            lastP1choice = true;
                            lastP2Choice = false;
                            print("pointsAwarded");
                        }
                        else if ((!p1Choicenst) && p2Choicenst)
                        {
                            p1Points = p1Points + BetrayerPoints;
                            p2Points = p2Points + BetrayedPoints;
                            print("1 , 0");
                            lastP1choice = false;
                            lastP2Choice = true;
                            print("pointsAwarded");
                        }
                        else if (!(p2Choicenst || p1Choicenst))
                        {
                            p1Points = p1Points + CheaterPoints;
                            p2Points = p2Points + CheaterPoints;
                            print("1  ,  1");
                            lastP1choice = false;
                            lastP2Choice = false;
                            print("pointsAwarded");
                        }
                    }
                } else if ((randomRoll <= chanceOfMistake) && (randomRollp2 > chanceOfMistake))
                {
                    print("player 1 missed");
                    if (is1stturn)
                    {
                        print("1stTurn");
                        if (p1Choice1st && p2Choice1st)
                        {
                            p1Points = p1Points + BetrayerPoints;
                            p2Points = p2Points + BetrayedPoints;
                            print("1 , 0");
                            lastP1choice = false;
                            lastP2Choice = true;
                            print("pointsAwarded");
                        }
                        else if (p1Choice1st && !p2Choice1st)
                        {
                            p1Points = p1Points + CheaterPoints;
                            p2Points = p2Points + CheaterPoints;
                            print("1 ,  1");
                            lastP1choice = false;
                            lastP2Choice = false;
                            print("pointsAwarded");
                        }
                        else if ((!p1Choice1st) && p2Choice1st)
                        {
                            p1Points = p1Points + CooperatorPoints;
                            p2Points = p2Points + CooperatorPoints;
                            print("0 , 0");
                            lastP1choice = true;
                            lastP2Choice = true;
                            print("pointsAwarded");
                        }
                        else if (!(p1Choice1st || p2Choice1st))
                        {
                            p1Points = p1Points + BetrayedPoints;
                            p2Points = p2Points + BetrayerPoints;
                            print("0, 1");
                            lastP1choice = true;
                            lastP2Choice = false;
                            print("pointsAwarded");
                        }
                        is1stturn = false;
                    }
                    else
                    {
                        print("not1stTurn");
                        if (p1Choicenst && p2Choicenst)
                        {
                            p1Points = p1Points + BetrayerPoints;
                            p2Points = p2Points + BetrayedPoints;
                            print("1 , 0");
                            lastP1choice = false;
                            lastP2Choice = true;
                            print("pointsAwarded");
                        }
                        else if (p1Choicenst && !p2Choicenst)
                        {
                            p1Points = p1Points + CheaterPoints;
                            p2Points = p2Points + CheaterPoints;
                            print("1 ,  1");
                            lastP1choice = false;
                            lastP2Choice = false;
                            print("pointsAwarded");
                        }
                        else if ((!p1Choicenst) && p2Choicenst)
                        {
                            p1Points = p1Points + CooperatorPoints;
                            p2Points = p2Points + CooperatorPoints;
                            print("0, 0");
                            lastP1choice = true;
                            lastP2Choice = true;
                            print("pointsAwarded");
                        }
                        else if (!(p1Choicenst || p2Choicenst))
                        {
                            p1Points = p1Points + BetrayedPoints;
                            p2Points = p2Points + BetrayerPoints;
                            print("0, 1");
                            lastP1choice = true;
                            lastP2Choice = false;
                            print("pointsAwarded");
                        }
                    }
                } else if ((randomRoll > chanceOfMistake) && (randomRollp2 <= chanceOfMistake))
                {
                    print("p2 Missed");
                    if (is1stturn)
                    {
                        print("1stTurn");
                        print("1");
                        if (p1Choice1st && p2Choice1st)
                        {
                            p1Points = p1Points + BetrayedPoints;
                            p2Points = p2Points + BetrayerPoints;
                            print("0 , 1");
                            lastP1choice = true;
                            lastP2Choice = false;
                            print("pointsAwarded");
                        }
                        else if (p1Choice1st && p2Choice1st)
                        {
                            p1Points = p1Points + CooperatorPoints;
                            p2Points = p2Points + CooperatorPoints;
                            print("0 ,  0");
                            lastP1choice = true;
                            lastP2Choice = true;
                            print("pointsAwarded");
                        }
                        else if ((!p1Choice1st) && p2Choice1st)
                        {
                            p1Points = p1Points + CheaterPoints;
                            p2Points = p2Points + CheaterPoints;
                            print("1 , 1");
                            lastP1choice = false;
                            lastP2Choice = false;
                            print("pointsAwarded");
                        }
                        else if (!(p1Choice1st || p2Choice1st))
                        {
                            p1Points = p1Points + BetrayerPoints;
                            p2Points = p2Points + BetrayedPoints;
                            print("1, 0");
                            lastP1choice = false;
                            lastP2Choice = true;
                            print("pointsAwarded");
                        }
                        is1stturn = false;
                    }
                    else
                    {
                        print("notFirstTurn");
                        if (p1Choicenst && p2Choicenst)
                        {
                            p1Points = p1Points + BetrayedPoints;
                            p2Points = p2Points + BetrayerPoints; ;
                            print("0 , 1");
                            lastP1choice = true;
                            lastP2Choice = false;
                            print("pointsAwarded");
                        }
                        else if (p1Choicenst && !p2Choicenst)
                        {
                            p1Points = p1Points + CooperatorPoints;
                            p2Points = p2Points + CooperatorPoints;
                            print("0 ,  0");
                            lastP1choice = true;
                            lastP2Choice = true;
                            print("pointsAwarded");
                        }
                        else if ((!p1Choicenst) && p2Choicenst)
                        {
                            p1Points = p1Points + CheaterPoints;
                            p2Points = p2Points + CheaterPoints;
                            print("1 , 1");
                            lastP1choice = false;
                            lastP2Choice = false;
                            print("pointsAwarded");
                        }
                        else if (!(p2Choicenst || p1Choicenst))
                        {
                            p1Points = p1Points + BetrayerPoints;
                            p2Points = p2Points + BetrayedPoints;
                            print("1, 0");
                            lastP1choice = false;
                            lastP2Choice = true;
                            print("pointsAwarded");
                        }
                    }
                } else if ((randomRoll <= chanceOfMistake) && (randomRollp2 <= chanceOfMistake))
                {
                    print("bothPlayersMissed");
                    if (is1stturn)
                    {
                        print("1stTurn");
                        if (p1Choice1st && p2Choice1st)
                        {
                            p1Points = p1Points + CheaterPoints;
                            p2Points = p2Points + CheaterPoints;
                            print("1 , 1");
                            lastP1choice = false;
                            lastP2Choice = false;
                            print("pointsAwarded");
                        }
                        else if (p1Choice1st && !p2Choice1st)
                        {
                            p1Points = p1Points + BetrayerPoints;
                            p2Points = p2Points + BetrayedPoints;
                            print("1 ,  0");
                            lastP1choice = false;
                            lastP2Choice = true;
                            print("pointsAwarded");
                        }
                        else if ((!p1Choice1st) && p2Choice1st)
                        {
                            p1Points = p1Points + BetrayerPoints;
                            p2Points = p2Points + BetrayedPoints;
                            print("0 , 1");
                            lastP1choice = true;
                            lastP2Choice = false;
                            print("pointsAwarded");
                        }
                        else if (!(p1Choice1st || p2Choice1st))
                        {
                            p1Points = p1Points + CooperatorPoints;
                            p2Points = p2Points + CooperatorPoints;
                            print("0  ,  0");
                            lastP1choice = true;
                            lastP2Choice = true;
                            print("pointsAwarded");
                        }
                        is1stturn = false;
                    }
                    else
                    {
                        print("not1stTurn");
                        if (p1Choicenst && p2Choicenst)
                        {
                            p1Points = p1Points + CheaterPoints;
                            p2Points = p2Points + CheaterPoints;
                            print("1 , 1");
                            lastP1choice = false;
                            lastP2Choice = false;
                            print("pointsAwarded");
                        }
                        else if (p1Choicenst && !p2Choicenst)
                        {
                            p1Points = p1Points + BetrayerPoints;
                            p2Points = p2Points + BetrayedPoints;
                            print("1 ,  0");
                            lastP1choice = false;
                            lastP2Choice = true;
                            print("pointsAwarded");
                        }
                        else if ((!p1Choicenst) && p2Choicenst)
                        {
                            p1Points = p1Points + BetrayedPoints;
                            p2Points = p2Points + BetrayerPoints;
                            print("0 , 1");
                            lastP1choice = true;
                            lastP2Choice = false;
                            print("pointsAwarded");
                        }
                        else if (!(p1Choicenst || p2Choicenst))
                        {
                            p1Points = p1Points + CooperatorPoints;
                            p2Points = p2Points + CooperatorPoints;
                            print("0  ,  0");
                            lastP1choice = true;
                            lastP2Choice = true;
                            print("pointsAwarded");
                        }
                    } 
                } 
            }
            p1Pointstxt.text = "" + p1Points;
            p2Pointstxt.text = "" + p2Points;
            p2Points = 0;
            p1Points = 0;
            is1stturn = true;
        }
        
    }
    // sets number of repeats
  public void setnofrepeats (string input)
    {
        nOfRepeat = int.Parse(input);
        print(nOfRepeat);
    }
    //sets chance to miss
    public void setChance2miss(float input)
    {
        chanceOfMistake = Mathf.FloorToInt(input);
    }
}
