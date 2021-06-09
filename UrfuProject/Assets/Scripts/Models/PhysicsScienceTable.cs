using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UrfuProject
{
    public class PhysicsScienceTable : MonoBehaviour, IScienceTable
    {

        //public GameObject[] questsPrefabs;
        //public GameObject questScroll;
        private HashSet<Quest> availableQuests;
        //private bool isQuestStart = false;


        [Header("Предметы для активации стола")]
        public GameObject buyTable;
        public GameObject inventory;

        //[Header("Свойства для открытия свитка")]
        //public GameObject player;
        //public GameObject scroll;
        //public Image armIndicator;
        //public KeyCode takeObjectKey = KeyCode.E;
        //public float interactDistance = 5f;
        //private float distanceToPlayer;

        private void Awake()
        {
            BoughtController.OnTryingToBuy.AddListener(() =>
            {
                buyTable.SetActive(false);
                inventory.SetActive(true);
            });
        }

        public void AddQuest(Quest newQuest)
        {
        }

        public void HideQuestScroll()
        {

        }

        public int QuestCount()
        {
            return availableQuests.Count;
        }
    }
}