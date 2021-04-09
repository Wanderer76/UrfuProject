using UnityEngine;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{
    public void Exit()
    {
        //TODO Save
        Application.Quit();
    }


    public void Continue()
    {
        //TODO Save
        SceneManager.LoadScene(1);
    }
}
