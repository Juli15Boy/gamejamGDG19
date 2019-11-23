using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpObject : MonoBehaviour
{
    [SerializeField]
    int pickUpId, pickupType, buff, debuff;
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

    public int getPickupType()
    {
        return pickupType;
    }
}
