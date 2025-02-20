using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlayer1 : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;

    bool isFlap = false;

    MiniManager1 miniManager1;

    // Start is called before the first frame update
    void Start()
    {
        miniManager1 = MiniManager1.Instance;
        
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            miniManager1.GameOver();
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if(isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp(_rigidbody.velocity.y * 10f, -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDead) return;

        isDead = true;

        animator.SetInteger("IsDie", 1);
        miniManager1.GameOver();
    }
}
