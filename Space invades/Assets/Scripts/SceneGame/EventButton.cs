using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventButton : MonoBehaviour
{
    
    [SerializeField]
    private UnityEvent OnClick;
    // Start is called before the first frame update
    public void OnMouseDown()
    {
        OnClick.Invoke();
    }
}
