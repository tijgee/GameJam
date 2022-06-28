using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int round = 1;
    public int seconds = 10;

    public GameObject enemy1;
    public float spawnTime;

    GameObject[] allObjects;

    void Start()
    {
        StartCoroutine(Timer());
        StartCoroutine(spawnEnemy());
    }

    void Update()
    {
        allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach(GameObject obj in allObjects){
            if(obj.GetComponent<Stats>() != null && obj.GetComponent<Stats>().health <= 0){
                obj.SetActive(false);
                StartCoroutine(destroyObject(obj));
            }
        }
        if(seconds <= 0)
        {
            round++;
            switch(round){
                case 2:
                    seconds = 5;
                    break;
                case 3:
                    seconds = 45;
                    break;
                case 4:
                    seconds = 70;
                    break;
                case 5:
                    seconds = 120;
                    break;
            }
        }
    }


    IEnumerator Timer()
    {
        while(true){
            seconds--;
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator destroyObject(GameObject obj){
        yield return new WaitForSeconds(3);
        Destroy(obj);
    }

    IEnumerator spawnEnemy()
    {
        while(true){
            if(seconds > 0){
                Vector3 enemyspawn = new Vector3(Random.Range(-8f, 8f), 7f, 0);
                Instantiate(enemy1, enemyspawn, Quaternion.identity);
                yield return new WaitForSeconds(spawnTime);
            }
        }
        
    }
}
