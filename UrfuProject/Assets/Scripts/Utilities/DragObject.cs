using UnityEngine;

public class DragObject : MonoBehaviour
{
    private float maxZOffset = -1.64f;
    private float minZOffset = 1f;

    private Vector3 offset;
    private float zCoord;

    void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    private Vector3 GetMouseAsWorldPoint()
    {

        Vector3 mousePoint = Input.mousePosition;
        //mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {

        /* transform.position = GetMouseAsWorldPoint() + offset;
         var position = transform.position;
        if(position.z < maxZOffset)
         {
             transform.position = new Vector3(position.x, position.y, maxZOffset);
         }*/

        var screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,zCoord);
        var worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        /*if (worldPosition.z >= minZOffset)
            worldPosition.z = minZOffset;
        if (worldPosition.z <= maxZOffset)
            worldPosition.z = maxZOffset;*/
        worldPosition.z = 0.015f;
        transform.position = worldPosition;
        Debug.Log($"ZCoord - {transform.position.z}");
    }
}
