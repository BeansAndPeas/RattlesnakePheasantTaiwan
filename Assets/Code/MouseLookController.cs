using UnityEngine;

public class MouseLookController : MonoBehaviour
{
    [Header("Camera")]
    public bool isMouseLocked, isFOVEnabled;
    public float cameraFOVMin, cameraFOVMax, fovIncrement, cameraRotXMin, cameraRotXMax, cameraRotYMin, cameraRotYMax, mouseSmooth;

    private Camera mouseCamera;
    private float mouseX, mouseY, mouseRotX, mouseRotY = -90f, mouseScroll, fov;
    private Transform mouseParent;

    private void Awake()
    {
        this.mouseCamera = Camera.main;
        UnityEngine.Debug.Log(this.mouseCamera);
        this.mouseParent = this.transform.parent;
        if (this.mouseCamera != null)
        {
            this.fov = this.mouseCamera.fieldOfView;
        }

        MouseLock();
    }

    private void Update()
    {
        MouseInput();
        RotateCamera();
        ZoomCamera();
    }

    private void MouseInput()
    {
        this.mouseX = Input.GetAxisRaw("Mouse X") * this.mouseSmooth;
        this.mouseY = Input.GetAxisRaw("Mouse Y") * this.mouseSmooth;
        this.mouseScroll = Input.GetAxisRaw("Mouse ScrollWheel");
    }

    private void RotateCamera()
    {
        this.mouseRotX += Mathf.Clamp(this.mouseX, -0.01f, 0.01f);
        Quaternion parentRotation = this.mouseParent.transform.localRotation;
        parentRotation.z = this.mouseRotX;
        this.mouseParent.transform.localRotation = parentRotation;

        this.mouseRotY += this.mouseY;
        this.mouseRotY = Mathf.Clamp(this.mouseRotY, this.cameraRotYMax, this.cameraRotYMin);

        Quaternion rotation = this.mouseCamera.transform.localRotation;
        this.mouseCamera.transform.localRotation = Quaternion.Euler(0f, this.mouseRotY, -90f);
    }

    private static float mapValue(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    private void MouseLock()
    {
        if (this.isMouseLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }

        Cursor.lockState = CursorLockMode.None;
    }

    private void ZoomCamera()
    {
        if (this.isFOVEnabled)
        {
            if (this.mouseScroll > 0f)
            {
                if (this.fov + this.fovIncrement >= this.cameraFOVMin && this.fov + this.fovIncrement <= this.cameraFOVMax)
                {
                    this.fov += fovIncrement;
                    this.mouseCamera.fieldOfView = fov;
                }
            }

            else if (this.mouseScroll < 0f)
            {
                if (this.fov - this.fovIncrement >= this.cameraFOVMin && this.fov - this.fovIncrement <= this.cameraFOVMax)
                {
                    this.fov -= fovIncrement;
                    this.mouseCamera.fieldOfView = fov;
                }
            }
        }
    }
}