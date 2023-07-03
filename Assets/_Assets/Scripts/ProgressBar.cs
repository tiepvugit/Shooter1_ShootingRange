using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private RectTransform _foreground;
    [SerializeField]
    private float _maxWidth;
    [SerializeField]
    private float _height;

    private void Awake()
    {
        _maxWidth = _foreground.rect.width;
        _height = _foreground.rect.height;
    }

    public void SetProgressValue(float progress)
    {
        var currentWidth = Mathf.Clamp01(progress) * _maxWidth;
        _foreground.sizeDelta = new Vector2(currentWidth, _height);
    }


}
