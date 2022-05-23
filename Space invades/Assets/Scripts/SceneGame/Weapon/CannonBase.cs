using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CannonBase : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;
    protected BulletPool _bulletPool;
    [SerializeField, Range(1,25)]
    private int _bulletCount;

    

    private void OnEnable()
    { 
        if(_bulletPool == null )
            _bulletPool = FindObjectOfType<BulletPool>();
        if(_bulletCount > 0)
        _bulletPool.AddBullets(_bulletPrefab,_bulletCount);
    }
    protected void BulletActivate(Transform bulletStartPos)
    {
        var bullet = _bulletPool.Shot(_bulletPrefab);
        bullet.transform.position = bulletStartPos.position;
        bullet.transform.Rotate(transform.rotation.eulerAngles);
        bullet.SetActive(true);
    }

    public abstract void Shot();
}
