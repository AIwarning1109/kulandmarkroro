using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRotate : MonoBehaviour
{
    float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 75f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
