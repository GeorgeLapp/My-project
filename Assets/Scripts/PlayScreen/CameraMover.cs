using UnityEngine;

public class CameraMover : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas canvas;
    void Start()
    {
        canvas.renderMode = RenderMode.WorldSpace; 
    }
    private void Update()
    {
        transform.Translate(Vector2.right / 300);
    }
    public void MoveCameraLeft()
    {
      //  transform.Translate(Vector2.left/20);
    }
    public void MoveCameraRight()
    {
        transform.Translate(Vector2.right/10);
    }

}
