using System;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    private Color _color;
    private Image _image;
    private Image _childImage;
    public Platform Platform => _platform;
    public Layer Layer { get; private set; }


    private void Awake()
    {
        _image = GetComponent<Image>();
        var layer = transform.parent.GetComponent<Layer>();

        _childImage = null;
        if (_platform != null)
            _childImage = _platform.transform.GetComponent<Image>();

        if (_childImage != null)
            _childImage.color = _image.color = layer.Color;

        Layer = GetComponentInParent<Layer>();
        _platform.Init(Layer);

    }


    public void SetTransparent(float value)
    {
        
        Color color;
        color = _image.color;
        color.a = value;
        _image.color = color;
        _childImage.color = color;
    }


}