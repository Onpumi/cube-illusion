using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    private Color _color;
    private Image _image;
    public Platform Platform => _platform;


    private void Awake()
    {
        _image = GetComponent<Image>();
        var layer = transform.parent.GetComponent<Layer>();
        Image childImage = null;
        if (_platform != null)
            childImage = _platform.transform.GetComponent<Image>();
        if (childImage != null)
            childImage.color = _image.color = layer.Color;
    }
}