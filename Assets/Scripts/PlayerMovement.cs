using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    public float mainCharXvel;
    public float mainCharYvel;
    public float mainCharZvel;

    public float rotationSpeed;

    public bool xForward;
    public bool zChange;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        mainCharXvel = 16.25f;
        mainCharYvel = 16.25f;
        mainCharZvel = 16.25f;

        rotationSpeed = 36.7f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) { transform.Translate(0, 0, mainCharZvel * Time.deltaTime); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(0, 0, -mainCharZvel * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(-mainCharXvel * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.W)) { transform.Translate(mainCharXvel * Time.deltaTime, 0, 0); }


        if (Input.GetKey(KeyCode.Q)) { transform.Translate(0, mainCharYvel * Time.deltaTime, 0); }
        if (Input.GetKey(KeyCode.E)) { transform.Translate(0, -mainCharYvel * Time.deltaTime, 0); }
    }
}
