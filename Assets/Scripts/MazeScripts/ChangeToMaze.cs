using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToMaze : MonoBehaviour
{
    private void OnMouseDown(){
        SceneManager.LoadScene("MazeInstructions");
    }

}
