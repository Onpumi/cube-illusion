using System;
using UnityEngine;

public class Ball  : MonoBehaviour
{
    [SerializeField] private Platform _currentPlatform;
    [SerializeField] private BallMover _ballMover;
    private SpriteRenderer _sprite;
    public int SortingOrder { get; private set; }
    public Vector3 NextPosition { get; private set; }
    public Platform CurrentPlatform => _currentPlatform;

    private void Start()
    {
        var platform = _currentPlatform.transform;
        var parentPlatform = platform.parent;
        _sprite = GetComponent<SpriteRenderer>();
        SortingOrder = _currentPlatform.SortingOrder + 1;
        transform.position = platform.position + Vector3.up * platform.localScale.y * 0.15f;
        
    }

    public void SetCurrentPlatform(Platform nextPlatform) => _currentPlatform = nextPlatform;
        
    public void TryJump( Platform nextPlatform )
    {
        
        if (_ballMover.IsStart()) return;
        _currentPlatform = nextPlatform;
        if( nextPlatform.transform.position.y > transform.position.y || nextPlatform.SortingOrder >= _sprite.sortingOrder )
          SetSortingSprite( nextPlatform );
        _ballMover.SetDirection( nextPlatform );
        _ballMover.StartJump( nextPlatform );
    }

    public void SetSortingSprite( Platform nextPlatform )
    {
        var _spritePlatform = GetComponent<SpriteRenderer>();
        _sprite.sortingOrder = nextPlatform.SortingOrder + 1;
    }


}
