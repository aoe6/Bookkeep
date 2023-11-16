using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickController : MonoBehaviour
{
    private void OnMouseDown(){
        SceneManager.LoadScene("AimTrainer");
    }

}
