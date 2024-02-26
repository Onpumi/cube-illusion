using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    [SerializeField] private Color _color = Color.white;
    public Color Color => _color;
    private List<Cube> _cubes;
    private bool _isActive = false;


    private void Awake()
    {
        _cubes = new List<Cube>();

        foreach (Transform child in transform)
        {
            if (child.TryGetComponent<Cube>(out Cube cube))
            {
                _cubes.Add(cube);
            }

            if (child.TryGetComponent<Ball>(out Ball ball))
                _isActive = true;
        }
    }

    public void SetActive(bool value)
    {

        var valueAlpha = (value) ? (1f) : (0.2f);
        _isActive = value;
        
        foreach (Cube cube in _cubes)
        {
            cube.SetTransparent(valueAlpha);
        }
        

    }
    


    private void Start()
    {
            SetActive(_isActive);
    }
}