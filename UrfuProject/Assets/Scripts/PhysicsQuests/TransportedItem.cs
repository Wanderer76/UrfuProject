using UnityEngine;
using UnityEngine.UI;

public class TransportedItem : Arm
{
    [Header("Физические данные")]
    public int mass = 10;
    private const int G = 10;
    public int Force { get; private set; }

    public Text massText;

    private void Awake()
    {
        Force = mass * G;
    }

    private void OnMouseEnter()
    {
        Debug.Log("Enter");
        massText.text = $"Масса: {mass}";
        massText.enabled = true;
    }

    private void OnMouseExit()
    {
        massText.enabled = false;
        armIndicator.enabled = false;
    }
}
