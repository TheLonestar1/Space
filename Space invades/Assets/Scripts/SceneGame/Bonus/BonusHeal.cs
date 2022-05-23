using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHeal : BonusBase
{
    [SerializeField, Range(100,1000)]
    private int _health = 100;

    protected override void Activate(GameObject player)
    {
        if(player.TryGetComponent(out PlayerHealth health))
        {
            health.AddHealth(_health);
        }
    }
}
