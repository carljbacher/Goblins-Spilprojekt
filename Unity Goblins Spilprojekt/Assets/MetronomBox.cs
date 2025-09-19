using System.ComponentModel.Design;
using UnityEditor.Rendering;
using UnityEngine;

public class MetronomBoxLogic : MonoBehaviour
{
    [SerializeField] float ChangeTime;
    [SerializeField] float StartOffset;
    private float Timer1;
    [SerializeField] private GameObject targetObject;
    private bool active1;
    public AudioSource StortSlag;
    public AudioSource LilleSlag;
    private bool Lydtest1;
    private bool Lydtest2;
    private bool Lydtest3;

    void Start()
    {
        Timer1 = StartOffset;
        StortSlag = GetComponent<AudioSource>();
        LilleSlag = GetComponent<AudioSource>();
    }


    void Update()
    {
        Timer1 = Timer1 + Time.deltaTime;

        if (Timer1 > ChangeTime / 4 && Lydtest1)
        {
            LilleSlag.Play();
            Lydtest1 = false;
        }

        if (Timer1 > ChangeTime / 2 && Lydtest2)
        {
            LilleSlag.Play();
            Lydtest2 = false;
        }

        if (Timer1 > 3 * ChangeTime / 4 && Lydtest3)
        {
            LilleSlag.Play();
            Lydtest3 = false;
        }

        if (Timer1 > ChangeTime)
        {
            Timer1 = 0;
            StortSlag.Play();
            if (active1)
            {
                targetObject.SetActive(true);
                active1 = false;
                Lydtest1 = true;
                Lydtest2 = true;
                Lydtest3 = true;
            }
            else
            {
                targetObject.SetActive(false);
                active1 = true;
                Lydtest1 = true;
                Lydtest2 = true;
                Lydtest3 = true;
            }
        }
        

    }
}
