using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject playerbody;
    [SerializeField] private float chekpointpoint;
    [SerializeField] private GameObject targetObject;
    public SpillerBevægelse SpillerBevægelse;
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        Debug.Log("Restart test 1");
        if (playerbody.transform.position.x < chekpointpoint)
            SceneManager.LoadScene("Level 1");
        else if (playerbody.transform.position.x > chekpointpoint)
        {
            targetObject.SetActive(false);
            Debug.Log("Restart test 2");
            SpillerBevægelse.resetPlayer();

            playerbody.transform.position = new Vector3(100, 6, 0);

            
        }

    }
}
