using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    MiniManager2 miniManager2;

    private void Start()
    {
        miniManager2 = MiniManager2.Instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            miniManager2.AddScore(1);
        }
    }
}
