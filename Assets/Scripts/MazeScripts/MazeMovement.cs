using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMovement : MonoBehaviour
{
    public float speed;
    public MazeTimer mazeTimer; 

    private Vector2 newPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float newX = gameObject.transform.position.x - Time.deltaTime * speed; 
            float newY = gameObject.transform.position.y;
            newPos = new Vector2(newX, newY);
            gameObject.transform.position = newPos;
            mazeTimer.StartTimerOnCharacterMove();
            // gameObject.GetComponent<SpriteRenderer>().flipX();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            float newX = gameObject.transform.position.x + Time.deltaTime * speed;
            float newY = gameObject.transform.position.y;
            newPos = new Vector2(newX, newY);
            gameObject.transform.position = newPos;
            mazeTimer.StartTimerOnCharacterMove();
            
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            float newX = gameObject.transform.position.x;
            float newY = gameObject.transform.position.y + Time.deltaTime * speed;
            newPos = new Vector2(newX, newY);
            gameObject.transform.position = newPos;
            mazeTimer.StartTimerOnCharacterMove();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            float newX = gameObject.transform.position.x;
            float newY = gameObject.transform.position.y - Time.deltaTime * speed;
            newPos = new Vector2(newX, newY);
            gameObject.transform.position = newPos;
            mazeTimer.StartTimerOnCharacterMove();
        }
    }
}