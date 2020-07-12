using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Transform spriteMask;
    public Transform start;
    public Transform exit;
    public GameObject image;
    public Text text;
    public List<string> messages = new List<string>();
    public bool opening;
    public bool credits;
    int message = 1;

    public void Update()
    {
        if (!credits)
        {
            spriteMask.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10));
        }

        if (Input.GetMouseButtonDown(0) && opening)
        {
            if (message < messages.Count)
            {
                text.text = messages[message];
                message++;
            }
            else if(!credits)
            {
                StartGame();
            } else
            {
                Quit();
            }
        }
        else if (!credits && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out RaycastHit hit) && Input.GetMouseButtonDown(0))
        {
            if(hit.transform == start)
            {
                Opening();
            }
            else if(hit.transform == exit)
            {
                Quit();
            }
        }

    }

    public void Opening()
    {
        opening = true;
        image.SetActive(true);
        text.text = messages[0];
    }

    public static void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
    }

    public static void Quit()
    {
        Application.Quit();
    }
}
