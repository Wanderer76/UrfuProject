using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        //private IEnumerator LoadAfterVideo()
        //{
        //    var async = SceneManager.LoadSceneAsync(Scenes.MainScene);
        //
        //    while (videoPlayer.isPlaying)
        //    {
        //        yield return null;
        //    }
        //    yield return async;
        //}

    }
}