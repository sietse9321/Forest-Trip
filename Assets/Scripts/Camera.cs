using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform turn;
    
    float rotateX;
    float rotateY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        rotateX -= mouseY;
        rotateY += mouseX;

        rotateX = Mathf.Clamp(rotateX, -90f, 90);

        transform.rotation = Quaternion.Euler(rotateX, rotateY, 0);
        turn.rotation = Quaternion.Euler(0, rotateY, 0);




    }
}
