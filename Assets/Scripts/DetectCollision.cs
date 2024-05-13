using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DetectCollision : MonoBehaviour
{
    public string kill;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(kill))
        {
            ReloadScene();
        }
    }
    void Update()
    {
        if (transform.position.y < -15f)
        {
            ReloadScene();
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
