using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public Animator animator;
    public bool open = false;
    public AudioSource ding;
    // Start is called before the first frame update
    void Awake()
    {
        Degradation.FinalDegradationEvent += Open;
    }

    private void Open()
    {
        Degradation.FinalDegradationEvent -= Open;
        open = true;
        if (animator != null)
        {
            animator.SetBool("Open", true);
        }
        if (ding != null)
        {
            ding.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && open)
        {
            Map map = FindObjectOfType<Map>();
            SceneManager.UnloadSceneAsync(map.index + 1);
            if (SceneManager.sceneCountInBuildSettings > map.index + 2)
            {
                SceneManager.LoadScene(map.index + 2, new LoadSceneParameters(LoadSceneMode.Additive));
                Degradation.Reset();
            }
            else
            {
                Degradation.button.Opening();
            }
        }
    }
}
