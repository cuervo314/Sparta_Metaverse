using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlayer3 : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public bool isDead = false;
    public bool isReflect = false;

    MiniManager3 miniManager3;
    MiniUIManager3 miniUIManager3;

    [SerializeField] private ParticleSystem shieldEffect;
    [SerializeField] private ParticleSystem disappearEffect;

    // Start is called before the first frame update
    void Start()
    {
        miniManager3 = MiniManager3.Instance;
        miniUIManager3 = FindObjectOfType<MiniUIManager3>();
        
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            animator.SetBool("IsDie", true);
            Time.timeScale = 0f;
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("FireBall"))
        {
            animator.SetBool("IsReflect", true);
            shieldEffect.Play();
            animator.SetBool("IsReflect", false);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            isDead = true;
        }
    }

    public void GameOver()
    {
        miniUIManager3.SetRestart();
    }
}
