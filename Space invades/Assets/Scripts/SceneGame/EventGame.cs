using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventGame : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnDie;
    public void Activate()
    {
        LevelNameData level = new LevelNameData();
        level.SetName("GameOver");
        level.SetLevelIndex(0);
        OnDie.Invoke();
    }
}
