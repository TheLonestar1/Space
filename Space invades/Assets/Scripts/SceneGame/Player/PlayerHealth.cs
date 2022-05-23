using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerHealth : ObjectHealth
{
    [SerializeField]
    private UnityEvent<int> OnChangeHealth;
    protected override void OnEnable()
    {
        base.OnEnable();
        OnChangeHealth.Invoke(GetCurrentHealth());
    }
    public override void TakeDamage(int value)
    {
        base.TakeDamage(value);
        OnChangeHealth.Invoke(GetCurrentHealth());
    }
    public override void AddHealth(int value)
    {
        base.AddHealth(value);

        OnChangeHealth.Invoke(GetCurrentHealth());
    }

}
