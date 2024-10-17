using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    // Start is called before the first frame update

    float xRotation;
    float yRotation;

    float rotationSpeed;
    void Start()
    {
        rotationSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * rotationSpeed;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        xRotation -= mouseY * rotationSpeed;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation + 90f, 0);
    }
}
