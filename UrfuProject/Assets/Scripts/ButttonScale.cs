using UnityEngine;

public class ButttonScale : MonoBehaviour
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        rectTransform.localScale = new Vector3(0.9f, 0.9f, 1);
    }

    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
        rectTransform.localScale = new Vector3(1, 1, 1);
    }
}
