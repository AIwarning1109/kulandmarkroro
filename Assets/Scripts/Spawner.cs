using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnerOffsetX;
    public float spawnerOffsetZ;
    // Start is called before the first frame update
    void Start()
    {
        spawnerOffsetX = 0f;
        spawnerOffsetZ = 0f;
        InvokeRepeating("Spawn", 3f, 1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        spawnerOffsetX = Random.Range(20, 61);
        spawnerOffsetZ = Random.Range(-55, 21);
        this.transform.position = new Vector3(spawnerOffsetX, 0, spawnerOffsetZ);
        GameObject clone = Instantiate(prefab);
        Destroy(clone, 10f);
        clone.transform.position = transform.position;
        clone.transform.rotation = transform.rotation;
    }
}