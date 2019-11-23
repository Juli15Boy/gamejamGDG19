using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpObject : MonoBehaviour
{
    [SerializeField]
    int pickUpId, buff, debuff;
    [SerializeField]
    string pickUpName;


    public int getBuff()
    {
        return buff; 
    }

    public int getDebuff()
    {
        return debuff;
    }
}
