using System;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    private AnimationCurve _jumpCurve;
    private readonly float _jumpTime = 0.5f;
    private float _time;
    private float _jumpHeight = 0.45f;
    private Vector3 _startPosition;
    private Vector3 _currentPosition;
    private Vector3 _direction;
    private bool _isFinishMove;
    private float _valueCurve;
    private bool _isFall = false;
    public event Action OnFinishGame;
    public event Action OnFinishJump;
    public bool IsFinishJump { get; private set; }


    private void Awake()
    {
        _jumpCurve = new AnimationCurve(new Keyframe[3]
        {
            new Keyframe(0f, 0f),
            new Keyframe(_jumpTime * 0.5f, 1f),
            new Keyframe(_jumpTime, 0f)
        });
        IsFinishJump = false;
    }

    public void SetDirection(Platform platform)
    {
        _direction = platform.transform.position - transform.position;
        _direction /= _jumpTime;
    }

    public void StartJump(Platform platform)
    {
        _time = _jumpTime;
        _startPosition = transform.position;
        _currentPosition = _startPosition;
        _isFinishMove = platform.IsFinish;
        IsFinishJump = false;
    }

    public bool IsStart() => _time > _jumpTime * (1f-_jumpTime);
//    public bool IsStart() => _time > 0;

    private void Jump()
    {
        //if( _time > 0)
        if (_time > (1f-_jumpTime) * (_jumpTime))
        {
            _time -= (Time.deltaTime * _jumpTime);
            _valueCurve = _jumpCurve.Evaluate((_jumpTime - _time) / _jumpTime) * _jumpHeight;
            _currentPosition += _direction * Time.deltaTime;
            transform.position = _currentPosition + (Vector3.up) * _valueCurve;
        }
        else
        {
            IsFinishJump = true;

            OnFinishJump?.Invoke();

            if (_isFinishMove)
            {
                OnFinishGame?.Invoke();
            }
        }
    }

    //public bool IsFall() => (_time < _jumpTime * 0.5f && _time > 0);
    public bool IsFall => (_time < _jumpTime * (1-_jumpTime*_jumpTime)  && _time > (_jumpTime)* (1f-_jumpTime));


    private void Update()
    {
            Jump();
    }
}