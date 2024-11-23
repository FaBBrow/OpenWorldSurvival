using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSsensitivity = 100;
    private float xRotation;
    private float yRotation;
    [SerializeField] private GameObject camera;
    private float cyclinderRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!InventorySystem.instance.isOpen)
        {
            var mouseX = Input.GetAxis("Mouse X") * mouseSsensitivity * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * mouseSsensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90f);

            yRotation += mouseX;
            cyclinderRotation = xRotation;
            cyclinderRotation = Mathf.Clamp(cyclinderRotation, -30, 30);
            transform.localRotation = Quaternion.Euler(cyclinderRotation, yRotation, 0f);
            camera.transform.rotation=Quaternion.Euler(xRotation,yRotation,0f);
        }
    }
}