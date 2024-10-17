using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public int aiIndex;
    public int patrolCounter;
    public bool patrolForward;
    public int patrolRange;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        this.aiIndex = Random.Range(0, 3);
        this.patrolCounter = 0;
        this.patrolForward = true;
        this.patrolRange = Random.Range(2, 9) * 10;
        this.speed = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.aiIndex == 0) // circle
        {
            transform.Rotate(0, this.patrolRange * 3f * Time.deltaTime, 0);
            transform.Translate(speed * Time.deltaTime, 0, speed * Time.deltaTime * 0.3f);
        } else if (this.aiIndex == 1) // back forth
        {
            if (patrolCounter > patrolRange)
            {
                patrolForward = false;
            }
            if (patrolCounter < 0)
            {
                patrolForward = true;
            }

            if (patrolForward)
            {
                transform.Translate(speed * Time.deltaTime, 0, speed * Time.deltaTime * 0.3f);
                patrolCounter++;
            } else
            {
                transform.Translate(-speed * Time.deltaTime, 0, -speed * Time.deltaTime * 0.3f);
                patrolCounter--;
            }
        }
        else // left right
        {
            if (patrolCounter > patrolRange)
            {
                patrolForward = false;
            }
            if (patrolCounter < 0)
            {
                patrolForward = true;
            }

            if (patrolForward)
            {
                transform.Translate(speed * Time.deltaTime * 0.3f, 0, speed * Time.deltaTime);
                patrolCounter++;
            }
            else
            {
                transform.Translate(-speed * Time.deltaTime * 0.3f, 0, -speed * Time.deltaTime);
                patrolCounter--;
            }
        }
    }
    private void OnDestroy()
    {
        ScoreManager.instance.numEnemies -=  1;
        HitManager.instance.numKills += 1;
    }
}
