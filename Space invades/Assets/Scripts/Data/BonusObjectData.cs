using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Bonuses")]
public class BonusObjectData : ScriptableObject
{
    public List<BonusBase> Bonuses = new List<BonusBase>();
}
