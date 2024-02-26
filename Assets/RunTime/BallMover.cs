using System;
using UnityEngine;

public class BallMover : MonoBehaviour
{

    private AnimationCurve _jumpCurve;
    private float _jumpTime = 1f;
    private float _time;
    private float _height = 10f;
    private float _jumpHeight = 5f;
    private Vector3 _startPosition;
    private Vector3 _currentPosition;
    private Vector3 _direction;
    private Platform _nextPlatform;
    private bool _isFinishMove;
    private float _valueCurve;
    private bool _isFall = false;
    public event Action OnFinishGame;
    //public bool IsFinishJump

    
    
    private void Awake()
    {
        _jumpCurve = new AnimationCurve(new Keyframe[3]{
 
            new Keyframe(0f ,0f),
            new Keyframe(0.5f,1f),
            new Keyframe(1f ,0f)
        });

    }
    public void SetDirection( Platform platform )
    {
        _direction = platform.transform.position - transform.position; 
        _nextPlatform = platform;
    }
    public void StartJump( Platform platform )
    {
        _time = _jumpTime;
        _startPosition = transform.position;
        _currentPosition = _startPosition;
        _isFinishMove = platform.IsFinish;
        _nextPlatform = platform;
        if (platform.transform.position.y < transform.position.y)
        {
            _jumpHeight = 0.45f;
        }
        else
        {
            _jumpHeight = 0.45f;
        }
    }

    public bool IsStart() => _time > 0;

    private void Jump()
    {
        if( _time > 0f)
        {
            _time-= Time.deltaTime;
            _valueCurve = _jumpCurve.Evaluate((_jumpTime - _time) / _jumpTime) * _jumpHeight;
            _currentPosition += _direction * Time.deltaTime * 1f;
            transform.position = _currentPosition + (Vector3.up) * _valueCurve;
        }
        else
        {
            if (_isFinishMove)
            {
                OnFinishGame?.Invoke();
            }
        }
        
    }

    public bool IsFall() => (_time < _jumpTime * 0.5f && _time > 0);
        

    private void Update()
    {
        Jump();
        //FinishJump();
    }
    
}
