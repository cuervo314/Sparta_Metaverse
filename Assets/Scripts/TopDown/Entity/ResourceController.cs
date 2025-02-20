using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = .5f;
    
    private BaseController4 baseController4;
    private StatHandler4 statHandler4;
    private AnimationHandler4 animationHandler4;

    private float timeSinceLastChange = float.MaxValue;

    public float CurrentHealth { get; private set; }
    public float MaxHealth => statHandler4.Health;

    public AudioClip damageClip;

    private Action<float, float> OnChangeHealth;

    private void Awake()
    {
        baseController4 = GetComponent<BaseController4>();
        statHandler4 = GetComponent<StatHandler4>();
        animationHandler4 = GetComponent<AnimationHandler4>();
    }

    private void Start()
    {
        CurrentHealth = statHandler4.Health;
    }

    private void Update()
    {
        if (timeSinceLastChange < healthChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange >= healthChangeDelay)
            {
                animationHandler4.InvincibilityEnd();
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        if (change == 0 || timeSinceLastChange < healthChangeDelay)
        {
            return false;
        }

        timeSinceLastChange = 0f;
        CurrentHealth += change;
        CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;
        CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth;

        OnChangeHealth?.Invoke(CurrentHealth, MaxHealth);

        if (change < 0)
        {
            animationHandler4.Damage();

            if (damageClip != null)
                SoundManager.PlayClip(damageClip);
        }

        if (CurrentHealth <= 0f)
        {
            Death();
        }

        return true;
    }

    private void Death()
    {
        baseController4.Death();
    }

    public void AddHealthChangeEvent(Action<float, float> action)
    {
        OnChangeHealth += action;
    }

    public void RemoveHealthChangeEvent(Action<float, float> action)
    {
        OnChangeHealth -= action;
    }
}
