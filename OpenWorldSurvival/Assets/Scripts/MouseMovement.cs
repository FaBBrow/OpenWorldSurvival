using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSsensitivity = 100;
    float xRotation = 0f;
    float yRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSsensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSsensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation=Mathf.Clamp(xRotation,-90,90f);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
