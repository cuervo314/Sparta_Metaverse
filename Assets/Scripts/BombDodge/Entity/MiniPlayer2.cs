using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlayer2 : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public bool isDead = false;

    MiniManager2 miniManager2;

    // Start is called before the first frame update
    void Start()
    {
        miniManager2 = MiniManager2.Instance;
        
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            miniManager2.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bomb"))
        {
            isDead = true;
            miniManager2.GameOver();
        }
    }
}
