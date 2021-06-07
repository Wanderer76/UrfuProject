using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace UrfuProject
{
    public class WeightQuestController : MonoBehaviour
    {
        public GameObject winPanel;
        public List<GameObject> boxes;
        //public GameObject prefab;
        private List<GameObject> boxesPositions;
        public Collider platform;


        private void Start()
        {
            boxesPositions = new List<GameObject>();
            //MathScroll.OnStartEvent += ((type) => { Debug.Log("EVENT"); if (type == QuestType.Weights) StartQuest(); });

            // foreach (var i in boxes)
            // {
            //     i.GetComponent<Rigidbody>().mass = Random.Range(2, 10);
            // }

            SortMasses(boxes);
        }

        private void SortXCoordinates(List<GameObject> sorted)
        {
            sorted.Sort((first, second) =>
            {
                var firstX = first.GetComponent<Transform>().position.x;
                var secondX = second.GetComponent<Transform>().position.x;
                return firstX > secondX ? -1 : 1;
            });
        }

        private void SortMasses(List<GameObject> ls)
        {
            ls.Sort((first, second) =>
            {
                var firstMass = first.GetComponent<Rigidbody>().mass;
                var secondMass = second.GetComponent<Rigidbody>().mass;
                return firstMass > secondMass ? 1 : -1;
            });
        }

        private void OnTriggerEnter(Collider collision)
        {
            foreach (var i in boxes.Where(i => collision.gameObject == i))
            {
                Debug.Log("Trigger enter");
                boxesPositions.Add(i);
            }
            SortXCoordinates(boxesPositions);
            CheckForWinning();
        }

        private void OnTriggerExit(Collider collision)
        {
            foreach (var i in boxes)
            {
                if (collision.gameObject == i)
                {
                    Debug.Log("Trigger exit");
                    boxesPositions.Remove(i);
                }
            }
            SortXCoordinates(boxesPositions);
        }

        private void CheckForWinning()
        {
            if (boxesPositions.Count != boxes.Count)
                return;

            bool isEqual = true;

            for (var i = 0; i < boxes.Count; i++)
            {
                if (boxesPositions[i] != boxes[i])
                {
                    isEqual = false;
                    break;
                }
            }

            if (!isEqual)
                Debug.Log("No");
            else
            {
                Debug.Log("Winn");
                winPanel.SetActive(true);
            }
        }

        public void StartQuest()
        {
            Debug.Log("Yes");
            //prefab.SetActive(true);
        }
    }
}
