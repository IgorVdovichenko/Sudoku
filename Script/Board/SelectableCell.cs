using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableCell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private SpriteRenderer background;
    private Color defaultColor;
    [SerializeField]
    private Color selectedColor;
    public Color textColor;

    public bool IsSelected { get; private set; }
    public bool IsInteractable { get; set; } = true;

    [HideInInspector]
    public SelectCellEvent onClick;

    public Vector2 gridPos = new Vector2();
    public Vector2 regionPos = new Vector2();

    private void OnEnable()
    {
        defaultColor = new Color(selectedColor.r, selectedColor.g, selectedColor.b, 0);
    }

    public void Select(bool value)
    {
        IsSelected = value;
        if (value == true)
            background.color = selectedColor;
        else
            background.color = defaultColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsInteractable == false)
            return;
        Select(!IsSelected);
        onClick.Invoke(this);
    }
}
