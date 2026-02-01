using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{

    string currentScene = "GamScene";

    public void SetScene(string newSTR) => currentScene = newSTR;

    public void Jugar()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}
