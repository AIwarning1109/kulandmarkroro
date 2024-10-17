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
        InvokeRepeating("Spawn", 3f, 1.75f);
    }

    // Update is called once per frame
    void Spawn()
    {
        ScoreManager.instance.numEnemies += 1;
        spawnerOffsetX = Random.Range(50, 61);
        spawnerOffsetZ = Random.Range(-40, 6);
        this.transform.position = new Vector3(spawnerOffsetX, 0, spawnerOffsetZ);
        GameObject clone = Instantiate(prefab);
        Destroy(clone, 60f);
        clone.transform.position = transform.position;
        clone.transform.rotation = transform.rotation;
    }
}