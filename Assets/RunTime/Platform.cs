
using System;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    [SerializeField] private bool _isFinish = false;
    private Button _button;
    private Image _image;
    public bool IsFinish => _isFinish;
    public event Action<Platform> OnClickButton;
    public Layer Layer { get; private set; }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _image.alphaHitTestMinimumThreshold = 0.5f;
    }

    public void Init(Layer layer)
    {
        Layer = layer;
    }
    
    private void Start()
    {
        _button.onClick.AddListener(Jump);
        _image.color = transform.parent.GetComponent<Image>().color;
    }

    private void Jump()
    {
       OnClickButton.Invoke(this);
    }
 
    
}
