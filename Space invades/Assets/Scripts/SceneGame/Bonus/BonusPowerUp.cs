using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPowerUp : BonusBase
{
    [SerializeField]
    private float _liveTime = 2f;
    private PowerUp _powerUp;
    protected override void Activate(GameObject player)
    {
        _powerUp = player.gameObject.GetComponent<PowerUp>();
        _powerUp.Activate(_liveTime);
    }
}
