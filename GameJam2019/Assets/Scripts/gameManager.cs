using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    public static bool GameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void killPlayer()
    {
        //TODO: Change it to reload scene
        //transform.position = spawnPoint.position;
        return;
    }
}
