using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BonusShield : BonusBase
{
    [SerializeField]
    private Shied _shieldPrefab;
    [SerializeField]
    private float _liveTime = 2f;
    private static Shied _currentShield;

    private void CheckShiled()
    {
        if(_currentShield == null)
            _currentShield = Instantiate(_shieldPrefab);
    }

    protected override void Activate(GameObject player)
    {
        CheckShiled();
        if(_currentShield.IsEnable == false)
        {
            SceneManager.MoveGameObjectToScene(_currentShield.gameObject, SceneManager.GetSceneByName("Game"));
        }
        _currentShield.Activate(_liveTime, player.transform);
    }
}
