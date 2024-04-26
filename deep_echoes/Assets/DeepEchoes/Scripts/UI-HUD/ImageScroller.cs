using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScroller : MonoBehaviour
{
    [SerializeField] private RawImage _bg;
    [SerializeField] private float _x, _y;

    void Update()
    {
        _bg.uvRect = new Rect(_bg.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _bg.uvRect.size);
    }
}
