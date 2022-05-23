using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventWin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private UnityEvent OnComplete;
    EnemyWaves enemy;
    private void Update()
    {

        enemy = GetComponent<EnemyWaves>();
        int isClear = 0;
        foreach(var item in enemy.Enemies)
            if(item == null)
            {
                isClear++;
            }
        if (isClear == enemy.Enemies.Count)
            Activate();
    }

    public void Activate()
    {
        LevelNameData level = new LevelNameData();
        level.SetName("GameWin");
        level.SetLevelIndex(0);
        OnComplete.Invoke();
    }
}
