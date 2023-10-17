using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMover : MonoBehaviour
{
    public GameObject camera;
    private void OnTriggerStay2D(Collider2D collision)
    {
        camera.GetComponent<CameraMover>().MoveCameraLeft();
    }
}
