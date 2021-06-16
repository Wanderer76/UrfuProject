using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace UrfuProject
{
    public class WeightQuest : MonoBehaviour
    {
        public QuestType Type { get; } = QuestType.Weights;

        public GameObject winPanel;
        public List<GameObject> boxes;
        private List<GameObject> boxesPositions;
        public Collider platform;
        public Quest CurrentQuest;

        private void Start()
        {
            boxesPositions = new List<GameObject>();
            
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

            var isEqual = true;

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
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                QuestManager.QuestCompleted(CurrentQuest);
                winPanel.GetComponent<Winning>().SetQuest(CurrentQuest);
                winPanel.GetComponent<Winning>().SetWinStatus();
                winPanel.SetActive(true);
                foreach(var gold in boxes)
                {
                    Destroy(gold);
                }
                
            }
        }
    }
}
