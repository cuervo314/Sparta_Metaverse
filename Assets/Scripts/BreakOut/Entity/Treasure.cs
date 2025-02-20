using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    MiniManager3 miniManager3;
    MiniPlayer3 miniPlayer3;

    private void Start()
    {
        miniManager3 = MiniManager3.Instance;
        miniPlayer3 = FindObjectOfType<MiniPlayer3>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireBall"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            miniPlayer3.isDead = true;
        }
    }
}
