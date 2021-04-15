using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace UrfuProject
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance = null;

        public static int CurrentScene { get; private set; }

        private LevelManager()
        {
            CurrentScene = SceneManager.GetActiveScene().buildIndex;
        }

        private void Start()
        {
            if (instance == null)
                instance = this;
            DontDestroyOnLoad(this);
        }

        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }
        public void StartQuest(int levelIndex)
        {
            CurrentScene = levelIndex;
            SceneManager.LoadScene(levelIndex);
        }

        public static void OnQuestCompleted()
        {
            //QuestManager.OnQuestCompleted.Invoke(CurrentScene);
            SceneManager.LoadScene(1);
        }
    }
}
