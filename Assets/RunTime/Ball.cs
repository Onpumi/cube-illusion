using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform _parentImage;
    [SerializeField] private Platform _currentPlatform;
    [SerializeField] private BallMover _ballMover;
    private SpriteRenderer _sprite;
    public int SortingOrder { get; private set; }
    public Vector3 NextPosition { get; private set; }
    public Platform CurrentPlatform => _currentPlatform;


    private void OnEnable()
    {

        foreach ( Transform child in _parentImage)
        {
            foreach (Transform cubeTransform in child)
            {
                if (cubeTransform.TryGetComponent<Cube>(out Cube cube))
                {
                    cube.Platform.OnClickButton += TryJump;
                }
                
            }
        }
        
    }


    private void OnDisable()
    {
        foreach ( Transform child in _parentImage)
        {
            foreach (Transform cubeTransform in child)
            {
                if (cubeTransform.TryGetComponent<Cube>(out Cube cube))
                {
                    cube.Platform.OnClickButton -= TryJump;
                }
                
            }
        }
    }


    public void TryJump(Platform nextPlatform)
    {
        
        if (_ballMover.IsStart() ||  _currentPlatform == nextPlatform ) return;
        _currentPlatform = nextPlatform;

        _ballMover.SetDirection(nextPlatform);
        _ballMover.StartJump(nextPlatform);
        
    }

    public void SetSortingSprite(Platform nextPlatform)
    {
        
        transform.SetSiblingIndex(nextPlatform.transform.parent.GetSiblingIndex()+1);

        if (transform.parent != nextPlatform.transform.parent.parent)
        {
            transform.SetParent(nextPlatform.transform.parent.parent);
        }
        
    }

   


    private void Update()
    {
        //  if (_ballMover.IsFall() && _currentPlatform.SortingOrder < _sprite.sortingOrder)
        if (_ballMover.IsFall())
        {
            SetSortingSprite(_currentPlatform);
        }
    }
}