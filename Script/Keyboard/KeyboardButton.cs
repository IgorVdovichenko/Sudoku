using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyboardButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    [Range(0,9)]
    private byte input;
    [HideInInspector]
    public ByteEvent onClick;

    public bool interactable = true;

    [SerializeField]
    private Image image;

    [SerializeField]
    private Color normalColor;

    [SerializeField]
    private Color disabledColor;

    private void Awake()
    {
        image.color = normalColor;
    }

    private void Update()
    {
        if (interactable)
            image.color = normalColor;
        else
            image.color = disabledColor;
    }

    public void Click()
    {
        onClick.Invoke(input);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(interactable)
            onClick.Invoke(input);
    }
}
