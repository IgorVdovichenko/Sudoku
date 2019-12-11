using UnityEngine;

public class Cell : MonoBehaviour
{
    private TextMesh textMesh;
    private MeshRenderer meshRenderer;

    private void OnEnable()
    {
        textMesh = GetComponent<TextMesh>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetText(byte digit)
    {
        meshRenderer.enabled = true;
        textMesh.text = digit.ToString();
    }

    public void HideText()
    {
        meshRenderer.enabled = false;
    }

    public void SetTextColor(Color color)
    {
        textMesh.color = color;
    }
}
