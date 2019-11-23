﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float velocity = 7f;
    private string pickupTag = "Pickup";
    private int pickupBuff = 0;
    private int pickupDeBuff = 0;
    private int pickupType = 0;
    private bool carriesLog = false;
    private int droppedLogs = 0;

    Vector2 movement;

    private Rigidbody2D rb;

    public Animator animator;
    public Animator effectsAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            //SceneManager.LoadScene("MainMenu");
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * velocity * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       // Debug.Log(col.gameObject.name + " : " + col.tag + " : " + Time.time);

        if(col.tag == pickupTag)
        {
            pickupDeBuff= col.GetComponent<pickUpObject>().getDebuff();
            pickupBuff = col.GetComponent<pickUpObject>().getBuff();
            pickupType = col.GetComponent<pickUpObject>().getPickupType();

            applyPickupEffects(col);
            //itemCount++;
        }
    }

    private void applyPickupEffects(Collider2D col)
    {
        Debug.Log(pickupType);
        //Pickup Type: 0 -> Nothing / 1 -> Oxygen / 2 -> Speed
        switch (pickupType)
        {
            //Nothing
            case 0:

                break;

            //Oxygen
            case 1:
                if (pickupBuff != 0)
                {
                    //Debug.Log("AddOxygen");
                    gameObject.GetComponent<OxygenManager>().addOxygen(pickupBuff);
                    effectsAnimator.SetTrigger("applyBuff");
                }
                else if (pickupDeBuff != 0)
                {
                    //Debug.Log("DesOxygen");
                    gameObject.GetComponent<OxygenManager>().loseOxygen(pickupDeBuff);
                    effectsAnimator.SetTrigger("applyDebuff");


                }
                Destroy(col.gameObject);
                break;

            //Speed
            case 2:
                if (pickupBuff != 0)
                {
                    //Debug.Log("AddVelocity");
                    effectsAnimator.SetTrigger("applyBuff");
                    velocity += pickupBuff;
                }
                else if (pickupDeBuff != 0)
                {
                    //Debug.Log("DesVelocity");
                    effectsAnimator.SetTrigger("applyDebuff");
                    velocity -= pickupDeBuff;
                }
                Destroy(col.gameObject);
                break;

            //Log
            case 3:
                if (!carriesLog)
                {
                    Debug.Log("DesVelocity by Log");
                    effectsAnimator.SetTrigger("applyDebuff");
                    velocity -= pickupDeBuff;
                    Destroy(col.gameObject);
                    carriesLog = true;
                }
                else
                {
                    Debug.Log("Can't pick log!");
                }
                break;

            //Drop Log
            case 4:
                if (carriesLog)
                {
                    droppedLogs++;
                    Debug.Log("Dropped Logs " + droppedLogs);

                    col.GetComponent<bridgeManager>().updateBridge(droppedLogs);
                    effectsAnimator.SetTrigger("applyBuff");
                    velocity += pickupBuff;
                    carriesLog = false;
                    if(droppedLogs == 3)
                    {
                        Destroy(col.gameObject);
                    }
                }
                else
                {
                    Debug.Log("I have no log!");
                }
                break;
        }
    }

    private void showAppliedEffect(bool isPositiveEffect)
    {
        if (isPositiveEffect)
        {

        }
        else
        {

        }
    }
}
