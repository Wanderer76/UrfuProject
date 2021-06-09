using UnityEngine;
using UnityEngine.SceneManagement;

namespace UrfuProject
{
    public class LevelManager : MonoBehaviour
    {
        private static LevelManager instance = null;


        private LevelManager()
        {
        }

        private void Start()
        {
            if (instance == null)
                instance = this;
            DontDestroyOnLoad(this);
        }

        public static void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }
        public void StartQuest(int levelIndex)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(levelIndex);
        }
        public void StartQuest(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }

        public static void OnQuestCompleted()
        {
            //QuestManager.OnQuestCompleted.Invoke(CurrentScene);
            SceneManager.LoadScene(1);
        }
    }
}
