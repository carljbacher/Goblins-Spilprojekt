using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class GameOverScreen : MonoBehaviour
{
    private Rigidbody2D playerbody;
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        if (playerbody.transform.position.x < 50)
            SceneManager.LoadScene("Level 1");

    }
}
