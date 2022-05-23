using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Weapon;
    private float _curretTime;
    private bool _isEnable;
    public bool IsEnable => _isEnable;
    public void Activate(float liveTime)
    {
        _curretTime += liveTime;
        if (_isEnable == false)
        {
            
            ActivateWeapon(true);
            StartCoroutine(Timer());
        }
    }

    private void ActivateWeapon(bool value)
    {
        foreach(var weapon in Weapon)
        {
            weapon.SetActive(value);
            weapon.gameObject.GetComponent<PlayerTimer>().StartTimer();
        }
        _isEnable = value;
    }

    private IEnumerator Timer()
    {
        float waitAndStep = 0.5f;

        WaitForSeconds wait = new WaitForSeconds(0.5f);

        while (_curretTime > 0)
        {
            _curretTime -= waitAndStep;
            yield return wait;
        }
        _curretTime = 0;
        ActivateWeapon(false);
    }
}
