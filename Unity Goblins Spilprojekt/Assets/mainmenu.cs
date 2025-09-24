using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Denne metode kaldes af Start-knappen
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Denne metode kaldes af Quit-knappen
    public void QuitGame()
    {
        Debug.Log("Quit pressed");
        Application.Quit();
    }

  
}
