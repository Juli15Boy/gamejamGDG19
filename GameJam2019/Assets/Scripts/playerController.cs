using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float velocity = 7f;
    private string pickupTag = "Pickup";
    private int pickupBuff = 0;
    private int pickupDeBuff = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * velocity * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * velocity * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * velocity * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * velocity * Time.deltaTime;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + col.tag + " : " + Time.time);

        pickupBuff = col.GetComponent<pickUpObject>().getBuff();
        pickupDeBuff = col.GetComponent<pickUpObject>().getDebuff();

        if (col.tag == pickupTag)
        {
            if (pickupBuff != 0)
            {
                Debug.Log("AddVelocity");
                velocity += pickupBuff;
            }
            else if (pickupDeBuff != 0)
            {
                Debug.Log("DesVelocity");
                velocity -= pickupDeBuff;
            }
            Destroy(col.gameObject);
        }
    }

}
