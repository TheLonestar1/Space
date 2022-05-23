using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderHorizontal : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField]
   private bool _isUp;
   
   private void Start()
   {
       SetPosition();
   }
    
    private void SetPosition()
    {
        float positionX = _isUp ? new SafeAreaData().GetMax().x : new SafeAreaData().GetMin().x;
        transform.position = new Vector2(positionX, transform.position.y);
    }
}
