using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [SerializeField]
    private List<KeyboardButton> keyboardButtons;

    private byte input;

    [HideInInspector]
    public ByteEvent onClick;

    private void Start()
    {
        InitializeButtons();
        Activate(false);
    }

    public void Activate(bool value)
    {
        foreach (var button in keyboardButtons)
            button.interactable = value;
    }

    private void InitializeButtons()
    {
        foreach (var button in keyboardButtons)
            button.onClick.AddListener(Click);
    }

    private void Click(byte input)
    {
        onClick.Invoke(input);
    }
}
