using UnityEngine;

public class ExtraDoor : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private float CamaraPositionRoom;
    [SerializeField] private CameraController cam;
    [SerializeField] private bool rightOrLeft;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            if (rightOrLeft)
                if (CamaraPositionRoom < cam.currentPosX)
                    cam.MoveToNewRoom(previousRoom);
            else
                if (CamaraPositionRoom > cam.currentPosX)
                    cam.MoveToNewRoom(previousRoom);                
        }
    }
}
