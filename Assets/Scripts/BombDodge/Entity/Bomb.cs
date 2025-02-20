using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    protected Animator animator;
    MiniManager2 miniManager2;
    MiniPlayer2 miniPlayer2;

    private void Start()
    {
        transform.position = new Vector2(Random.Range(-10, 10), Random.Range(2, 5));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            animator = collision.gameObject.GetComponentInChildren<Animator>();
            animator.SetBool("IsDie", true);
        }
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetBool("IsFall", true);
        Destroy(this.gameObject, 0.9f);
    }
}
