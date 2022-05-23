using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyWaves : MonoBehaviour
{
    [SerializeField]
    private BonusGenerate _bonusGenerator;
    [SerializeField]
    private BonusQuene _bonusQuene;
    [SerializeField]
    private UnityEvent OnEventWin;

    private LevelData _level;
    private int _indexWave;
    private int _indexEnemy;

    private List<GameObject> _enemies = new List<GameObject> ();

    private void Awake()
    {
        int index = new LevelNameData().GetLevelIndex()+1;
        _level = Resources.Load<LevelData>($"Levels/Level{index}");
    }
    public List<GameObject> Enemies => _enemies;
    public int IndexWave => _indexWave;
    public void Generate()
    {
        int offset = 1;
        Vector2 startPosition = new Vector2(0, new SafeAreaData().GetMax().y + offset);

        foreach (var wave in _level.waves)
        {
            for(int i = 0; i < wave.CountInWave; i++)
            {
                var enemy = Instantiate(wave.EnemyPrefab,transform);
                if(enemy.TryGetComponent(out EnemyBonusDrop enemyBonusDrop))
                {
                    
                    enemyBonusDrop.SetBonusQueue(_bonusQuene);
                    enemyBonusDrop.SetHaveBonus(_bonusGenerator.TryBonus());


                }
                
                
                enemy.transform.position = startPosition;
                enemy.SetActive(false);
                _enemies.Add(enemy);

            }
        }
    }
    public void Activate()
    {
        StartCoroutine(EnemyActivate());
    }

    private IEnumerator EnemyActivate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);
        WaitForSeconds waitGame = new WaitForSeconds(5f);
        var count = _level.waves[_indexWave].CountInWave;
        while(count > 0)
        {
            count--;
            _enemies[_indexEnemy].gameObject.SetActive(true);
            _indexEnemy++;
            yield return wait;
        }
        
        if(_indexWave < _level.waves.Count - 1)
        {
            Invoke(nameof(Activate), _level.waves[_indexWave].WaitAfterWave);
            _indexWave++;
        }
        yield return waitGame;
        OnEventWin.Invoke();


    }

    
}
