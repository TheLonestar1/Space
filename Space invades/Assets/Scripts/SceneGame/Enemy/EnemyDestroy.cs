using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyAnimationDestroy))]
public class EnemyDestroy : MonoBehaviour
{
    
    public void Activate()
    {
        Destroy(gameObject);
        
    }
    
}
