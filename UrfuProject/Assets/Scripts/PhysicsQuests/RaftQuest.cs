using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UrfuProject
{
    public class RaftQuest : MonoBehaviour
    {
        public static Quest currentQuest;
        public GameObject winPanel;

        public int mass = 50; //kg
        public int density = 1000; //kg/m^3
        private const int G = 10;
        private float ArchimedForce;
        private HashSet<TransportedItem> items;
        public static UnityEvent OnLaunchRaft = new UnityEvent();

        public GameObject player;
        public Text massAndDensityText;

        private void Awake()
        {
            ArchimedForce = mass * density * G;
            items = new HashSet<TransportedItem>();
            OnLaunchRaft.AddListener(() => { LaunchRaft(); });

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<TransportedItem>(out var item))
            {
                if (item != null)
                {
                    items.Add(item);
                    Debug.Log($"Added {item}");
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<TransportedItem>(out var item))
            {
                if (item != null)
                {
                    items.Remove(item);
                    Debug.Log($"Removed {item}");
                }
            }
        }


        private void OnMouseOver()
        {
            if (Vector3.Distance(transform.position, player.GetComponent<Transform>().position) < 8)
            {
                massAndDensityText.text = $"Масса: {mass}\nПлотность {density}";
                massAndDensityText.enabled = true;
            }
        }
        private void OnMouseExit()
        {
            massAndDensityText.enabled = false;
        }

        public void LaunchRaft()
        {
            var allForce = 0;
            var winning = winPanel.GetComponent<Winning>();
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            foreach (var item in items)
            {
                allForce += item.Force;
            }
            Debug.Log($"Archimed force = {ArchimedForce}, SummaryForce = {allForce}");
            winning.SetQuest(currentQuest);
            if (ArchimedForce - allForce <= 500)
            {
                winning.SetWinStatus();
            }
            else
            {
                GetComponent<Rigidbody>().isKinematic = false;
                winning.SetFailStatus();
            }
            winPanel.SetActive(true);
        }
    }
}