using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Manager
    public GameObject roundDisplay;
    public GameObject healthDisplay;
    public GameObject textDisplay;
    public GameObject player;

    private GameManager manager;
    void Start()
    {
        manager = GetComponent<GameManager>();
        textDisplay.GetComponent<Text>().text = manager.seconds.ToString();
        roundDisplay.GetComponent<Text>().text = manager.round.ToString();
        healthDisplay.GetComponent<Text>().text = player.GetComponent<Stats>().healthMax.ToString();
    }

    void Update()
    {
        textDisplay.GetComponent<Text>().text = manager.seconds.ToString();
        roundDisplay.GetComponent<Text>().text = manager.round.ToString();
        healthDisplay.GetComponent<Text>().text = player.GetComponent<Stats>().health.ToString();
    }

}
