using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class MeleeWeaponHandler : WeaponHandler
{ 
    [Header("Melee Attack Info")]
    public Vector2 collideBoxSize = Vector2.one;

    protected override void Start()
    {
        base.Start();
        collideBoxSize = collideBoxSize * WeaponSize;
    }

    public override void Attack()
    {
        base.Attack();

        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position + (Vector3)Controller.LookDirection * collideBoxSize.x,
            collideBoxSize, 0, Vector2.zero, 0, target);

        if(hit.collider != null)
        {
            ResourceController resourceController = hit.collider.GetComponent<ResourceController>();
            if (resourceController != null)
            {
                resourceController.ChangeHealth(-Power);
                if(IsOnKnockback)
                {
                    BaseController4 controller4 = hit.collider.GetComponent<BaseController4>();
                    if(controller4 != null)
                    {
                        controller4.ApplyKnockback(transform, KnockbackPower, KnockbackTime);
                    }
                }
            }
        }
    }

    public override void Rotate(bool isleft)
    {
        if(isleft)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }    
    }
}
