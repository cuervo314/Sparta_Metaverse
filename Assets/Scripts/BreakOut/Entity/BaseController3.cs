using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseController3 : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    protected GameObject Player;
    protected Animator animator;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection {  get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    protected StatHandler3 statHandler3;
    protected AnimationHandler3 animationHandler3;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        statHandler3 = GetComponent<StatHandler3>();
        animationHandler3 = GetComponent<AnimationHandler3>();
    }

    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }

    private void Movement(Vector2 direction)
    {
        direction = direction * statHandler3.Speed;

        _rigidbody.velocity = direction;
        animationHandler3.Move(direction);

        if(_rigidbody.velocity.sqrMagnitude > 0)
        {
            Rotate(lookDirection);
        }
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;
        Debug.Log(direction);
    }
}
