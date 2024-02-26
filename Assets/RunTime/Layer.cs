using UnityEngine;
using UnityEngine.UI;

public class Layer : MonoBehaviour
{
    [SerializeField] private Color _color = Color.white;
    public Color Color => _color;
}