using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundImage : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> _sprites;
    private float _OffsetY = 0f;

    private void Start()
    {
        if(_sprites.Count > 0)
            SetImagesPosition();
    }
    private void SetImagesPosition()
    {
        transform.position = new Vector2(transform.position.x, new SafeAreaData().GetMin().y);
        for(int i = 0; i < _sprites.Count; i++)
        {
            GameObject image = new GameObject("image", typeof(SpriteRenderer));
            image.GetComponent<SpriteRenderer>().sprite = _sprites[i];
            image.transform.SetParent(transform);
            image.transform.position = new Vector2(transform.position.x, transform.position.y + _OffsetY);
            _OffsetY += _sprites[i].bounds.size.y;
        }
    }
}
