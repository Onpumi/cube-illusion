using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform _parentImage;
    [SerializeField] private Platform _currentPlatform;
    [SerializeField] private BallMover _ballMover;
    private SpriteRenderer _sprite;


    private void OnEnable()
    {
        foreach (Transform child in _parentImage)
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
        foreach (Transform child in _parentImage)
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
        if (_ballMover.IsStart() || _currentPlatform == nextPlatform) return;

        Debug.Log(Vector2.Distance(_ballMover.transform.position, nextPlatform.transform.position));
        if (Vector2.Distance(_ballMover.transform.position, nextPlatform.transform.position) > 0.9f) return;

        _currentPlatform = nextPlatform;
        _ballMover.SetDirection(nextPlatform);
        _ballMover.StartJump(nextPlatform);
    }

    public void SetSortingSprite(Platform nextPlatform)
    {
        transform.SetSiblingIndex(nextPlatform.transform.parent.GetSiblingIndex() + 1);

        if (transform.parent != nextPlatform.transform.parent.parent)
        {
            //if (_ballMover.transform.position.y < nextPlatform.transform.position.y)
            transform.SetParent(nextPlatform.transform.parent.parent);
            transform.SetAsLastSibling();
        }
    }


    private void Update()
    {
        Transform parentTransform = null;
        if (_currentPlatform != null)
            parentTransform = _currentPlatform.transform.parent.parent;
        if (_ballMover.IsFall())
        {
            SetSortingSprite(_currentPlatform);
        }
        else
        {
            if (_currentPlatform != null && transform.parent != parentTransform)
            {
                if (_currentPlatform.transform.position.y > _ballMover.transform.position.y)
                {
                    if (_ballMover.transform.GetSiblingIndex() < parentTransform.GetSiblingIndex())
                        transform.SetParent(_currentPlatform.transform.parent.parent);
                    transform.SetAsLastSibling();
                }
            }
        }
    }
}