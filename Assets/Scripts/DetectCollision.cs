using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DetectCollision : MonoBehaviour
{
    public string kill;
    public string NextLevel;
    
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(kill))
        {
            ReloadScene();
        }

        if (other.gameObject.CompareTag(NextLevel))
        {
            NextScene();
        }
    }
    void Update()
    {
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void NextScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene (assuming scenes are ordered in build settings)
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
