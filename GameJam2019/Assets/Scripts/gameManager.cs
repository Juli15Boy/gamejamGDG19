using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            killPlayer();
        }
    }

    public void killPlayer()
    {
        //TODO: Change it to reload scene
        //transform.position = spawnPoint.position;
        SceneManager.LoadScene("SampleScene");
        return;
    }
}
