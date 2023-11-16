using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves Sprite1 and Sprite2
        if (collision.gameObject.CompareTag("Player") && collision.otherCollider.CompareTag("Finish"))
        {
            // Change the scene to MainMenu
            SceneManager.LoadScene("MainMenu");
        }
    }
}