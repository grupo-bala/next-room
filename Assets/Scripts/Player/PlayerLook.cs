using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerBody;
    public float sensitivity = 100.0f;

    float xRotation = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * this.sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * this.sensitivity * Time.deltaTime;

        this.xRotation -= mouseY;
        this.xRotation = Mathf.Clamp(this.xRotation, -90f, 90f);

        this.transform.localRotation = Quaternion.Euler(this.xRotation, 0.0f, 0.0f);
        this.playerBody.Rotate(Vector3.up * mouseX);
    }
}
