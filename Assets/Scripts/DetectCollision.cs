using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DetectCollision : MonoBehaviour
{
    public string kill;
    public string NextLevel;
    public string PortalIn;
    public string PortalOut;
    public string Key;
    public string Door;
    private bool hasKey = false;
    
    
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
        if (other.gameObject.CompareTag(PortalIn))
        {
            // Teleport the player to the destination
            TeleportToDestination();
        }
        if (other.gameObject.CompareTag(Key))
        {
            hasKey = true;
            Destroy(other.gameObject); // Destroy the key object
        }
        if (hasKey && other.gameObject.CompareTag(Door))
        {
            Destroy(other.gameObject); // Destroy the door object
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
    private void TeleportToDestination()
    {
        // Find the GameObject with the destination tag
        GameObject destination = GameObject.FindGameObjectWithTag(PortalOut);
        
        // Check if destination is found
        if (destination != null)
        {
            // Move the player to the destination position
            transform.position = destination.transform.position;
        }
        else
        {
            Debug.LogError("Destination not found!");
        }
    }
}
