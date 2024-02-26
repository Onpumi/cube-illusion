
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
    public int SortingOrder { get; private set;  }
    public bool IsFinish => _isFinish;
    public event Action<Platform> OnClickButton; 

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _image.alphaHitTestMinimumThreshold = 0.5f;
    }


    private void OnEnable()
    {
        _button.onClick.AddListener(Jump);
        _image.color = transform.parent.GetComponent<Image>().color;
    }

    private void Jump()
    {
        
       OnClickButton.Invoke(this);
    }
 
  

    private bool TestAllowLayerJump( Ball ball )
    {
        return ball.SortingOrder <= SortingOrder && ball.transform.position.y <= transform.position.y - 0.2f;
    }
}
