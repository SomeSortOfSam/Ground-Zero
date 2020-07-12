using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public Transform mask;
    public Transform invertMask;
    public Transform startOver;
    public Transform exitOver;
    public Transform titleOver;
    public Transform startUnder;
    public Transform exitUnder;
    public Transform titleUnder;
    Vector2 startPos;
    Vector2 exitPos;
    Vector2 titlePos;
    public void Start()
    {
        startPos = startOver.position;
        exitPos = exitOver.position;
        titlePos = titleOver.position;
    }
    public void Update()
    {
        mask.position = Input.mousePosition;
        invertMask.position = Input.mousePosition;
        startOver.position = startPos;
        exitOver.position = exitPos;
        titleOver.position = titlePos;
        startUnder.position = startPos;
        exitUnder.position = exitPos;
        titleUnder.position = titlePos;
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
