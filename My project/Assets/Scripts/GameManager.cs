using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Manager
    public GameObject roundDisplay;
    public GameObject healthDisplay;
    int round = 1;
    

    //Timer
    public GameObject textDisplay;
  
    

    int secondsLeft = 10;
    public bool takingAway = false;

    //Enemies
    bool enemySpawn;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    

    public float waittime;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        roundDisplay.GetComponent<Text>().text = round.ToString();
        
        PlayerHealthSystem healthSystem = new PlayerHealthSystem(3);
        healthDisplay.GetComponent<Text>().text = healthSystem.GetHealth().ToString();
    }

    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            enemySpawn = true;
            StartCoroutine(TimerTake());
            StartCoroutine(Enemyspawn());
        }

        if(secondsLeft <= 0)
        {
            round++;
            
           
            enemySpawn = false;
            //round++;
            switch (round)
            {
                case 2:
                   
                    secondsLeft = 5;
                    roundDisplay.GetComponent<Text>().text = round.ToString();
                    break;
                case 3:
                    secondsLeft = 45;
                    roundDisplay.GetComponent<Text>().text = round.ToString();
                    break;
                case 4:
                    secondsLeft = 70;
                    roundDisplay.GetComponent<Text>().text = round.ToString();
                    break;
                case 5:
                    secondsLeft = 40;
                    roundDisplay.GetComponent<Text>().text = round.ToString();
                    break;
                case 6:
                    secondsLeft = 0;
                    break;
            }
        }
    }


    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10 && secondsLeft > 0)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
        }

        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        }
        takingAway = false;
        
        //yield return new WaitForSeconds(20);
        enemySpawn = false;
        //round++;
       
    }

 

    IEnumerator Enemyspawn()
    {
        while (enemySpawn)
        {
            Vector3 enemyspawn = new Vector3(Random.Range(-8f, 8f), 7f, 0);
            Instantiate(enemy1, enemyspawn, Quaternion.identity);
            yield return new WaitForSeconds(waittime);
        }
    }
}
