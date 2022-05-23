using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventGamaOver : MonoBehaviour
{
    
    [SerializeField]
    private UnityEvent OnNext;
    public void Activate()
    {
        //ScoreCollector collector = new ScoreCollector();
        //collector.SetScoreCollected(0);
        LevelNameData level = new LevelNameData();
        level.SetName("Map");
        level.SetLevelIndex(0);
        OnNext.Invoke();
    }
}
