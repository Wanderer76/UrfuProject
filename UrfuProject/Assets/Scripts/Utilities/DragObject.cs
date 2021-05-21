using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;

    private void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private Vector3 GetMouseWorldPosition()
    {

        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + offset;
    }
}
