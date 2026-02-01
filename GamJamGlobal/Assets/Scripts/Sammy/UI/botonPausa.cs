using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonPausa : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;

    public void PauseGame()

    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);

    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void RestarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
