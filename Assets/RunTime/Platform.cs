
using System;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _maxAllowDistanceForJump;
    [SerializeField] private bool _isFinish = false;
    private Ball _ball;
    private BallMover _ballMover;
    private Button _button;
    private Image _image;
    public bool IsFinish => _isFinish;
    public Image Image => _image;
    public event Action<Platform> OnClickButton; 

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _image.alphaHitTestMinimumThreshold = 0.5f;
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
