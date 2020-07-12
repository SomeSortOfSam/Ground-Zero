using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public Transform spriteMask;
    public Transform start;
    public Transform exit;

    public void Update()
    {
        spriteMask.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10));
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out RaycastHit hit) && Input.GetMouseButtonDown(0))
        {
            if(hit.transform == start)
            {
                StartGame();
            }
            else if(hit.transform == exit)
            {
                Quit();
            }
        }
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
