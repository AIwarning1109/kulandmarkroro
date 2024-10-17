using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement_strong : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}