using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace UrfuProject
{
    public class QuestButton : MonoBehaviour
    {
        public Text ButtonText { get; set; }
        public int SceneIndex { get; set; }

        public void OnMouseDown()
        {
            SceneManager.LoadScene(SceneIndex);
        }

        public void SetText(string text)
        {
            ButtonText.text = text;
        }


        private void Awake()
        {
            ButtonText = GetComponentInChildren<Text>();
        }


    }
}