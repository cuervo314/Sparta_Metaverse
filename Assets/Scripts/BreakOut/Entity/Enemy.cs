using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    MiniManager3 miniManager3 = MiniManager3.Instance;

    public GameObject enemy;
    Rigidbody2D _rigidbody;
    Animator animator;

    private float bigDemonSpeed = 0.5f;
    private int bigDemonLife = 3;
    private float chortSpeed = 1.5f;
    private int chortLife = 2;
    private float impSpeed = 2.5f;
    private int impLife = 1;

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        if (enemy.name == "BigDemon(Clone)")
        {
            _rigidbody.velocity = Vector2.left * bigDemonSpeed;
        }
        else if (enemy.name == "Chort(Clone)")
        {
            _rigidbody.velocity = Vector2.left * chortSpeed;
        }
        else
        {
            _rigidbody.velocity = Vector2.left * impSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemy.name == "BigDemon(Clone)")
        {
            if (collision.gameObject.CompareTag("FireBall"))
            {
                bigDemonLife--;
            }

            if (bigDemonLife == 0)
            {
                animator.SetBool("IsDie", true);
                _rigidbody.velocity = Vector2.zero;
                Invoke("Dead", 1f);
                miniManager3.AddScore(1);

            }
        }
        else if (enemy.name == "Chort(Clone)")
        {
            if (collision.gameObject.CompareTag("FireBall"))
            {
                chortLife--;
            }

            if (chortLife == 0)
            {
                animator.SetBool("IsDie", true);
                _rigidbody.velocity = Vector2.zero;
                Invoke("Dead", 1f);
                miniManager3.AddScore(1);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("FireBall"))
            {
                impLife--;
            }

            if (impLife == 0)
            {
                animator.SetBool("IsDie", true);
                _rigidbody.velocity = Vector2.zero;
                Invoke("Dead", 1f);
                miniManager3.AddScore(1);
            }
        }

    }

    public void Dead()
    {
        Destroy(this.gameObject);
    }
}
