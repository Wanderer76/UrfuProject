using UnityEngine;
using UnityEngine.UI;

namespace UrfuProject
{
    public class QuestScrollController : MonoBehaviour
    {
        public GameObject player;
        public GameObject scroll;
        public Image armIndicator;
        public KeyCode takeObjectKey = KeyCode.E;
        public float interactDistance = 5f;
        private float distanceToPlayer;

        private void FixedUpdate()
        {
            distanceToPlayer = Vector3.Distance(player.GetComponent<Transform>().position, transform.position);

            if (distanceToPlayer < interactDistance)
            {
                armIndicator.enabled = true;
                if (Input.GetKeyDown(takeObjectKey))
                {
                    ShowScroll();
                }
            }
            else
                armIndicator.enabled = false;
        }

        private void OnMouseExit()
        {
            armIndicator.enabled = false;
        }

        public void ShowScroll()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            scroll.SetActive(true);
        }
        public void SetQuest(Quest quest)
        {
            scroll.GetComponent<Scroll>().SetQuest(quest);
            this.enabled = true;
        }

        public void HideScroll()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            scroll.SetActive(false);
        }
    }
}