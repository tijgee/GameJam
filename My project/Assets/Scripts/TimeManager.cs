using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    //Timer
    public GameObject textDisplay;
    public int secondsLeft = 30;
    public bool takingAway = false;

    //Enemies
    public GameObject enemy;
    public float waittime;
    public float round;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
    }

    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
            StartCoroutine(Enemyspawn());
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        else
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        takingAway = false;
    }

    IEnumerator Enemyspawn()
    {
        while (true)
        {
            Vector3 enemyspawn = new Vector3(Random.Range(-8f, 8f), 7f, 0);
            Instantiate(enemy, enemyspawn, Quaternion.identity);
            yield return new WaitForSeconds(waittime);
        }
    }
}
