using UnityEngine;

namespace UrfuProject
{
    public class QuestButtonSpawner : MonoBehaviour
    {
        private readonly QuestButton[] quests = new QuestButton[4];
        public GameObject questButtonPrefab;
        public GameObject parent;

        private void Awake()
        {
            CreateButtons();
        }

        public void CreateButtons()
        {
            for (var i = 0; i < quests.Length; i++)
            {
                quests[i] = Instantiate(questButtonPrefab, transform).GetComponent<QuestButton>();
            }

            for (var i = 0; i < quests.Length; i++)
            {
                quests[i].SetText($"{i}");
            }
        }
    }
}