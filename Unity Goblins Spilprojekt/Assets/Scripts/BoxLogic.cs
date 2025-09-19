using System.ComponentModel.Design;
using UnityEditor.Rendering;
using UnityEngine;

public class BoxLogic: MonoBehaviour
{
    [SerializeField] float ChangeTime;
    [SerializeField] float StartOffset;
    private float Timer1;
    [SerializeField] private GameObject targetObject;
    private bool active1;


    void Start()
    {
        Timer1 = StartOffset;
    }


    void Update()
    {
        Timer1 = Timer1 + Time.deltaTime;

        if (Timer1 > ChangeTime)
        {
            Timer1 = 0;
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
