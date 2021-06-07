using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UrfuProject
{
    public class MathScienceTable : MonoBehaviour, IScienceTable
    {
        public GameObject[] questsPrefabs;
        public GameObject questScroll;
        private HashSet<Quest> availableQuests;
        private bool isQuestStart = false;

        [Header("Свойства для открытия свитка")]
        public GameObject player;
        public GameObject scroll;
        public Image armIndicator;
        public KeyCode takeObjectKey = KeyCode.E;
        public float interactDistance = 5f;
        private float distanceToPlayer;


        private void Start()
        {
            availableQuests = new HashSet<Quest>();
            QuestManager.GetNewQuests(); 
        }

        private void FixedUpdate()
        {
            foreach (var quest in QuestManager.Quests.Where(q => q.ScienceType == ScienceType.Math))
            {
                availableQuests.Add(quest);
            }
            if (availableQuests.Count > 0 && !isQuestStart)
            {
               questScroll.SetActive(true);
            }

            distanceToPlayer = Vector3.Distance(player.GetComponent<Transform>().position, transform.position);

            if (distanceToPlayer < interactDistance && questScroll.activeSelf)
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

        public void HideScroll()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            scroll.SetActive(false);
        }

        public void ShowScroll()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            scroll.GetComponent<MathScroll>().SetQuest(availableQuests.First());
            scroll.SetActive(true);
        }


        public void HideQuestScroll()
        {
            questScroll.SetActive(false);
        }
        public void AddQuest(Quest newQuest)
        {
            availableQuests.Add(newQuest);
        }

        public int QuestCount()
        {
            return availableQuests.Count;
        }

        public void ShowQuestScroll()
        {
            throw new System.NotImplementedException();
        }

        List<Quest> IScienceTable.GetQuests()
        {
            throw new System.NotImplementedException();
        }
        public void AcceptQuest()
        {
            var quest = availableQuests.First();
            var prefab = questsPrefabs.Where(pref => pref.GetComponentInChildren<WeightQuestController>() != null).First();
            prefab.SetActive(true);
            isQuestStart = true;
            HideScroll();
            HideQuestScroll();
        }
    }
}