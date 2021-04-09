using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace UrfuProject
{
    public class QuestButton : MonoBehaviour
    {

        public Text ButtonText { get; set; }

        public int SceneIndex { get; set; }

        public int Index { get; set; }

        public UnityEvent<int> OnDelete;

        public QuestButton(string text, int scene, int index)
        {
            if (ButtonText == null)
                ButtonText = GetComponentInChildren<Text>();

            ButtonText.text = text;
            SceneIndex = scene;
            Index = index;
        }

        public void OnMouseDown()
        {
            Destroy();
            SceneManager.LoadScene(SceneIndex);
        }

        public void SetText(string text)
        {
            ButtonText.text = text;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void Awake()
        {
            ButtonText = GetComponentInChildren<Text>();
        }
    }
}