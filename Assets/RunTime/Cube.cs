using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    [SerializeField] private Ball _ball;
    [SerializeField] private BallMover _ballMover;
    [SerializeField] private int _sortingOrder = 0;
    private Color _color;
    private SpriteRenderer _spriteRenderer;
    public BallMover BallMover => _ballMover;
    public Ball Ball => _ball;
    public Platform Platform => _platform;

    public int SortingOrder { get; private set;  } 
        




    
}
