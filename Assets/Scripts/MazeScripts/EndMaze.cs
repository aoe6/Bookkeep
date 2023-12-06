using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public MazeTimer mazeTimer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves Sprite1 and Sprite2
        if (collision.gameObject.CompareTag("Player") && collision.otherCollider.CompareTag("Finish"))
        {
            mazeTimer.EndTimer();
        }
    }
}
