using System;
using UnityEngine;

public class BallMover : MonoBehaviour
{

    private AnimationCurve _jumpCurve;
    private float _jumpTime = 0.5f;
    private float _time;
    private float _height = 10;
    private float _jumpHeight = 0.5f;
    private Vector3 _startPosition;
    private Vector3 _currentPosition;
    private Vector3 _direction;
    private Platform _nextPlatform;
    private bool _isFinishMove;

    public event Action OnFinishGame;
    
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
        _direction = platform.transform.position + Vector3.up * platform.transform.localScale.y * 0.15f - transform.position;
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
            _jumpHeight = 0.3f;
        }
        else
        {
            _jumpHeight = 0.5f;
        }
    }

    public bool IsStart() => _time > 0;



    public void FinishJump()
    {
        if (_nextPlatform != null)
        {
            
            if (Vector3.Distance(transform.position, _nextPlatform.transform.position) < 0.3f && _isFinishMove)
            {
                OnFinishGame?.Invoke();
            }
        }
    }
    
    private void Jump()
    {
        float value;

        if( _time > 0f)
        {
            _time-= Time.deltaTime;
            value = _jumpCurve.Evaluate((_jumpTime - _time) / _jumpTime) * _jumpHeight;
            _currentPosition += _direction * Time.deltaTime * 2f;
            transform.position = _currentPosition + (Vector3.up) * value;
        }
        
    }


    private void Update()
    {
        Jump();
        FinishJump();
    }
    
}
