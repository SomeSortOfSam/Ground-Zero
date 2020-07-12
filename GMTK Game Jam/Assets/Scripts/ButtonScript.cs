using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public Transform mask;
    public Transform spriteMask;
    public Transform start;
    public Transform exit;
    Vector2 startPos;
    Vector2 exitPos;
    public void Start()
    {
        startPos = start.position;
        exitPos = exit.position;
    }
    public void Update()
    {
        mask.position = Input.mousePosition;
        spriteMask.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10));
        start.position = startPos;
        exit.position = exitPos;
    }
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
