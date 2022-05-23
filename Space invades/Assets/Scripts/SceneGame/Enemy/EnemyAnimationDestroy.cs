using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EnemyAnimationDestroy : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> _sprites;
    [SerializeField, Range(0f, 2f)]
    private float _shotInterval = 0.5f;   
    [SerializeField]
    private UnityEvent _onDestroy;
    private WaitForSeconds _wait;

    public float GetTime()
    {
        return _shotInterval * _sprites.Count;
    }
    public void Activate()
    {

        _wait = new WaitForSeconds(_shotInterval);
        StartCoroutine(Animation());

    }
    private IEnumerator Animation()
    {
        foreach (var sprite in _sprites)
        {
            GetComponent<SpriteRenderer>().sprite = sprite;
            yield return _wait;
        }
        _onDestroy.Invoke();
    }
}
