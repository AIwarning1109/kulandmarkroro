using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyScript : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;

    float mainCharVel;    

    public float rotationSpeed;

    public bool xForward;
    public bool zChange;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        mainCharVel = 1000f;

        rotationSpeed = 36.7f;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(verticalInput * mainCharVel * Time.deltaTime, rb.velocity.y, 
            horizontalInput * -mainCharVel * Time.deltaTime);

    }
}
