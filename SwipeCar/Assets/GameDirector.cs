using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private GameObject car;
    private GameObject flag;
    private GameObject distance;

    // Use this for initialization
    void Start()
    {
        car = GameObject.Find("car");
        flag = GameObject.Find("flag");
        distance = GameObject.Find("Distance");
    }

    // Update is called once per frame
    void Update()
    {
        float length = this.flag.transform.position.x - this.car.transform.position.x;
        if (length >= 0)
        {
            this.distance.GetComponent<Text>().text = "ゴールまで" + length.ToString("F2") + "m";
        }
        else
        {
            distance.GetComponent<Text>().text = "game over";
        }
    }
}