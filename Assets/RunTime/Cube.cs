using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private int _sortingOrder = 0;
    private Color _color;
    private SpriteRenderer _spriteRenderer;
    private Platform _platform;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _color = _spriteRenderer.color;
        _platform = transform.GetChild(0).GetComponent<Platform>();
        _platform.SetColor(_color);
        _color.a = 1f / (1f + (5f * Vector3.Distance(transform.position, _ball.transform.position)));
    }


    private void OnValidate()
    {
        GetComponent<SpriteRenderer>().sortingOrder = _sortingOrder;
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            child.GetComponent<SpriteRenderer>().sortingOrder = _sortingOrder;
        }
    }


    private void Update()
    {
      //_color.a = 1f / (1f + (5f * Vector3.Distance(transform.position, _ball.transform.position)));
      _color.a = Mathf.Lerp(_color.a, 1f / (1f + (10f * Vector3.Distance(transform.position, _ball.transform.position))), Time.deltaTime * 10f);
      _spriteRenderer.color = _color;
      _platform.SetColor(_color);
    }
    
}
