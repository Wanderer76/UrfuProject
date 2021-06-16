using UnityEngine;
using UnityEngine.Video;

namespace UrfuProject
{
    public class MainMenu : MonoBehaviour
    {
        public VideoPlayer videoPlayer;

        public void Quit()
        {
            Debug.Log("Выход");
            Application.Quit();
        }

        public void StartGame()
        {
            QuestManager.GetNewQuests();
            if (GameStatistic.isGameNew)
            {
                videoPlayer.Play();
                GameStatistic.isGameNew = false;
                videoPlayer.loopPointReached += (player) => { LevelManager.LoadLevel(Scenes.MainScene); };
            }
            else
            {
                GameStatistic.isGameNew = false;
                LevelManager.LoadLevel(Scenes.MainScene);
            }
        }
    }
}