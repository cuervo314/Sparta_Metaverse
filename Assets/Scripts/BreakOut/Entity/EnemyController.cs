using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bigDemon;
    public GameObject imp;
    public GameObject chort;

    public void SpawnEnemy()
    {
        InvokeRepeating("CreateEnemy", 0, 2.5f);
    }

    public void CreateEnemy()
    {
        float i = Random.Range(0, 100);

        if (i < 33)
        {
            Instantiate(bigDemon, new Vector2(Random.Range(9.75f, 12f), Random.Range(-3.75f, 4.25f)), Quaternion.identity);
        }
        else if (i < 66)
        {
            Instantiate(chort, new Vector2(Random.Range(9.75f, 12f), Random.Range(-3.75f, 4.25f)), Quaternion.identity);
        }
        else
        {
            Instantiate(imp, new Vector2(Random.Range(9.75f, 12f), Random.Range(-3.75f, 4.25f)), Quaternion.identity);
        }
    }
}
