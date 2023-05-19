using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollerBackground : MonoBehaviour
{

    [SerializeField]
    private RawImage _imgBackground;

    [SerializeField]
    private float _speedX, _speedY;

    // Update is called once per frame
    void Update()
    {
        _imgBackground.uvRect = new Rect(_imgBackground.uvRect.position + new Vector2(_speedX, _speedY) * Time.deltaTime, _imgBackground.uvRect.size);
    }
}
