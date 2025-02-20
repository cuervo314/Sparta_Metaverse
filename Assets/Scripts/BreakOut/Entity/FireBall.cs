using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;

    private Vector2 direction;
    private Vector2 direction2;
    float Speed = 5f;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        direction = Vector2.right.normalized;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }

    public void Update()
    {     
            _rigidbody.velocity = direction * Speed;        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Treasure"))
        {
            Destroy(this.gameObject);
        }

        direction = Vector2.Reflect(direction, collision.contacts[0].normal).normalized;

        if (direction.x < 0)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
