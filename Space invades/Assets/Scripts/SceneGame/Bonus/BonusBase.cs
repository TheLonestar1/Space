using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public abstract class BonusBase : MonoBehaviour
{
    private const int Speed = 2;
    [SerializeField]
    private UnityEvent Activated;

    [SerializeField, Range(10,100)]
    private int _weight = 10;

    public int Weight => _weight;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerController controller))
        {
            Activate(controller.gameObject);
            Activated.Invoke();
            gameObject.SetActive(false);
        }
    }
    protected virtual void Activate(GameObject player)
    {

    }

    private void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        if (transform.position.y < new SafeAreaData().GetMin().y)
            gameObject.SetActive(false);
    }
}
