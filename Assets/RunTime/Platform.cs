
using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private BallMover _ballMover;
    [SerializeField] private float _maxAllowDistanceForJump;
    [SerializeField] private bool _isFinish = false;
    public SpriteRenderer SpriteRenderer { get; private set; }
    public int SortingOrder { get; private set;  }
    public bool IsFinish => _isFinish;

    private void Awake()
    {
        if( SpriteRenderer == null )
         SpriteRenderer = GetComponent<SpriteRenderer>();
        SortingOrder = SpriteRenderer.sortingOrder;
        transform.parent.GetComponent<SpriteRenderer>().sortingOrder = SortingOrder;
    }

    public void SetColor( Color color )
    {
        if( SpriteRenderer == null )
            SpriteRenderer = GetComponent<SpriteRenderer>();

        SpriteRenderer.color = color;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Ball ball) && ball.transform.position.y > transform.position.y + 0.3f && ball.CurrentPlatform != this 
            
            )
        {
            ball.SetSortingSprite(this);
        }
    }

    private void OnMouseDown()
    {
        if (TestAllowLayerJump(_ball)) return;
        if( Vector3.Distance(_ball.transform.position,transform.position) < _maxAllowDistanceForJump  )
         _ball.TryJump( this );
    }

    private bool TestAllowLayerJump( Ball ball )
    {
        return ball.SortingOrder <= SortingOrder && ball.transform.position.y <= transform.position.y - 0.2f;
    }
}
