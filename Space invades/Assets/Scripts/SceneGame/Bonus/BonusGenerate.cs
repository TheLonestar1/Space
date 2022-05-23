using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGenerate : MonoBehaviour
{
    [SerializeField]
    private BonusQuene _bonusQuene;
    [SerializeField]
    private BonusObjectData _bonusObjectData;

    private List<int> _bonusChance = new List<int>();

    private int _maxChance;
    private void Awake()
    {
        Calculate();
    }

    private void Calculate()
    {
        for(int i = 0; i < _bonusObjectData.Bonuses.Count; i++)
        {
            _maxChance += _bonusObjectData.Bonuses[i].Weight;
            _bonusChance.Add(_maxChance);
            
        }
        _bonusChance.Add(_maxChance * 3);
    }

    public bool TryBonus()
    {
        
        int chance = UnityEngine.Random.Range(0, _bonusChance[_bonusChance.Count - 1]);
        bool yesChance = false;

        if(chance > 0)
        {
            int min = 0;

            for(int i = 0; i < _bonusChance.Count - 1; i++)
            {                
                if(chance < min && chance < _bonusChance[i])
                {
                    Generate(_bonusObjectData.Bonuses[i].gameObject);
                    yesChance = true;
                    break;
                }
                min = _bonusChance[i];
            }

        }
        
        return yesChance;
    }
    
    private void Generate(GameObject bonusPrefab)
    {
        GameObject bonus = Instantiate(bonusPrefab, _bonusQuene.transform);
        bonus.SetActive(false);
        _bonusQuene.AddObject(bonus);
    }    
}
