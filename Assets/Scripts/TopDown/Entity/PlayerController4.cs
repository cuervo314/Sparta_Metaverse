using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController4 : BaseController4
{
    private Camera camera;
    private MiniManager4 miniManager4;

    public void Init(MiniManager4 miniManager4)
    {
        this.miniManager4 = miniManager4;
        camera = Camera.main;
    }

    protected override void HandleAction()
    {







    }

    public override void Death()
    {
        base.Death();
        miniManager4.GameOver();
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnLook(InputValue inputValue)
    {
        Vector2 mousePosition = inputValue.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }

    void OnFire(InputValue inputValue)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        isAttacking = inputValue.isPressed;
    }
}
