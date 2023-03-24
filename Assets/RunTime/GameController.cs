using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private WindowsWin _windowsWin;
    [SerializeField] private BallMover _ballMover;

    public void FinishGame()
    {
        _windowsWin.transform.gameObject.SetActive(true);
        _ballMover.enabled = false;
    }

    private void OnEnable()
    {
        _ballMover.OnFinishGame += FinishGame;
    }

    private void OnDisable()
    {
        _ballMover.OnFinishGame -= FinishGame;
    }
}
