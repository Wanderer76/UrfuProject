using UnityEngine;

public class DragObject : MonoBehaviour
{
    public float maxZOffset = -1.8f;
    private Vector3 offset;
    private float zCoord;

    void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {

        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {

        transform.position = GetMouseAsWorldPoint() + offset;
        if (transform.position.z > maxZOffset)
        {
            var position = transform.position;
            transform.position = new Vector3(position.x, position.y, maxZOffset);
        }
    }
}
