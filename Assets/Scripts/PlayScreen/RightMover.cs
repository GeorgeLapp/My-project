using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMover : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject camera;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name=="Player")
        {
            camera.GetComponent<CameraMover>().MoveCameraRight();
        }
        
    }
}
