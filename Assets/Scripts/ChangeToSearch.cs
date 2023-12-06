using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToSearch : MonoBehaviour
{
    void OnMouseDown(){
        SceneManager.LoadScene("SearchInstructions");
    }    
}
