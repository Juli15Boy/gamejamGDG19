using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class mainController : MonoBehaviour
{
    public void ChangeScene(string nombre)
    {
        //Cambiar a la escena principal
        SceneManager.LoadScene(nombre);
    }

    public void Leave()
    {
        //Saliendo del juego
        Application.Quit();
    }
}
