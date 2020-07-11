using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
