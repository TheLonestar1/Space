using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D), typeof(SpriteRenderer))]
public class EventMap : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro _text;
    [SerializeField]
    private UnityEvent OnClick;
    private int _index;
    public void SetParameters(Sprite sprite, int index)
    {
        GetComponent<SpriteRenderer>().sprite =  sprite;
        _index = index;
        _text.text = _index.ToString();
    }
    public void OnMouseDown()
    {
        LevelNameData level = new LevelNameData();
        level.SetName("Game");
        level.SetLevelIndex(_index);
        OnClick.Invoke();
    }
}
