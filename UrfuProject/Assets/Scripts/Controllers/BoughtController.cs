using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UrfuProject
{
    public class BoughtController : MonoBehaviour
    {
        public int price = 250;
        public int sciencePoints = 300;

        public GameObject player;
        public Image armIndicator;
        public GameObject boughtScroll;
        public KeyCode takeObjectKey = KeyCode.E;
        public float interactDistance = 5f;
        private float distanceToPlayer;
        private Transform playerTransform;

        public static UnityEvent OnTryingToBuy = new UnityEvent();

        private void Awake()
        {
            playerTransform = player.GetComponent<Transform>();
        }

        private void OnMouseOver()
        {
            if (gameObject.activeSelf)
            {
                distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
                if (distanceToPlayer < interactDistance)
                {
                    armIndicator.enabled = true;

                    if (Input.GetKeyDown(takeObjectKey))
                    {
                        boughtScroll.GetComponent<BoughtScroll>().Activate(price.ToString(), sciencePoints.ToString());
                        boughtScroll.SetActive(true);
                        Cursor.lockState = CursorLockMode.None;
                        Time.timeScale = 0;
                    }
                }
                else
                    armIndicator.enabled = false;
            }
        }

        public void AcceptBought()
        {
            if (GameStatistic.Money >= price && GameStatistic.SciencePoints >= sciencePoints)
            {
                OnTryingToBuy?.Invoke();
                GameStatistic.Money -= price;
                GameStatistic.SciencePoints -= sciencePoints;
                CloseScroll();
                GameStatistic.OnStatsChanged?.Invoke();
                armIndicator.enabled = false;
            }
        }

        public void CloseScroll()
        {
            boughtScroll.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }

        private void OnMouseExit()
        {
            armIndicator.enabled = false;
        }
    }
}