using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderVertical : MonoBehaviour
{
   [SerializeField]
   private bool _isUp;
   
   private void Start()
   {
       SetPosition();
   }
    
    private void SetPosition()
    {
        float positionY = _isUp ? new SafeAreaData().GetMax().y : new SafeAreaData().GetMin().y;
        transform.position = new Vector2(transform.position.x, positionY);
    }
}
