using System.ComponentModel.Design;
using UnityEditor;
using UnityEngine;

public class BoxLogicMotronom : MonoBehaviour
{
    [SerializeField] float ChangeTime;
    [SerializeField] float StartOffset;
    private float Timer1;
    [SerializeField] private GameObject targetObject;
    private bool active1;
    public AudioSource audioSource;

    void Start()
    {
        Timer1 = StartOffset;
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        Timer1 = Timer1 + Time.deltaTime;

        if (Timer1 > ChangeTime)
        {
            Timer1 = 0;
            audioSource.Play();
            if (active1)
            {
                targetObject.SetActive(true);
                active1 = false;
            }
            else
            {
                targetObject.SetActive(false);
                active1 = true;
            }
        }
        

    }
}
