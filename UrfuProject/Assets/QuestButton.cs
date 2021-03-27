using UnityEngine;
using UnityEngine.UI;


namespace UrfuProject
{
    public class QuestButton : MonoBehaviour
    {
        public Text ButtonText { get; set; }

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