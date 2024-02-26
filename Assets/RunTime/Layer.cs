using UnityEngine;
using UnityEngine.UI;

public class Layer : MonoBehaviour
{
    [SerializeField] private Color _color = Color.white;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent<Cube>(out Cube cube))
            {
                var image = child.GetComponent<Image>();
                image.color = _color;
            }
        }
    }
}
