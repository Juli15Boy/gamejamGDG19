using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class OxygenManager : MonoBehaviour
{

    public int timeLeft = 60; //Seconds Overall
    public Text countdown; //UI Text Object

    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }

    void Update()
    {
        if(timeLeft <= 0)
        {
            //TODO: Die animation
            gameObject.GetComponent<gameManager>().killPlayer();
        }
        else
        {
            countdown.text = ("" + timeLeft); //Showing the Score on the Canvas
        }
    }

    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }

    }

    public void addOxygen(int amount)
    {
        timeLeft += amount;
    }

    public void loseOxygen(int amount)
    {
        timeLeft -= amount;
    }
}