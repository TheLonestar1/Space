using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBonusDrop : MonoBehaviour
{
    private bool _haveBonus;
    private BonusQuene _bonusQuene;

    public void SetBonusQueue(BonusQuene bonusQuene)
    {
        _bonusQuene = bonusQuene;
    }

    public void SetHaveBonus(bool value)
    {
        _haveBonus = value;
    }

    public void Activate()
    {
        if (_haveBonus)
            _bonusQuene.Activate(transform.position);
    }
}
