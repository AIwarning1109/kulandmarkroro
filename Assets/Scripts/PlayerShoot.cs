using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject clone = Instantiate(prefab);
            Destroy(clone, 2f);
            clone.transform.position = transform.position;
            clone.transform.rotation = transform.rotation;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject clone2 = Instantiate(prefab2);
            Destroy(clone2, 2f);
            clone2.transform.position = transform.position;
            clone2.transform.rotation = transform.rotation;
        }
    }
}
