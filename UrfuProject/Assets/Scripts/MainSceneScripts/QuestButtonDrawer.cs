//using System.Collections.Generic;
//using UnityEngine;

//namespace UrfuProject
//{
//    public class QuestButtonDrawer : MonoBehaviour
//    {
//        private readonly List<QuestButton> buttons = new List<QuestButton>(6);

//        public GameObject buttonPrefab;
//        private LevelManager Manager;

//        public void CreateButtons()
//        {
//            var quests = QuestManager.Quests;

//            for (var i = 0; i < quests.Count; i++)
//            {
//                if (quests[i].IsCompleted == true)
//                    continue;

//                if (buttons.Capacity > i)
//                    buttons.Add(Instantiate(buttonPrefab, transform).GetComponent<QuestButton>());


//                buttons[i].SetText($"{quests[i].Title}\n{quests[i].MainText}");
//                buttons[i].SceneIndex = quests[i].SceneIndex;
//                buttons[i].Index = i;
//                buttons[i].Button.onClick.AddListener(() =>
//                {
//                    Manager.StartQuest(buttons[i].SceneIndex);
//                });
//            }
//        }

//        private void OnEnable()
//        {
//            CreateButtons();
//        }

//        private void OnDisable()
//        {
//            DeleteAll();
//        }

//        private void DeleteAll()
//        {
//            foreach (var v in buttons)
//            {
//                if (v != null)
//                    v.Destroy();
//            }
//            buttons.Clear();
//        }
//    }
//}