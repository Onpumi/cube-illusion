using System;
using UnityEngine;
using  UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>() ?? throw new ArgumentException("Button exit is null");
        _button.onClick.AddListener(delegate {  Application.Quit(); });
    }
    
    
}
