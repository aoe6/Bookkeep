using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InstructionSceneController : MonoBehaviour
{
    public void StartGame(string sceneToLoad){
        SceneManager.LoadScene(sceneToLoad);
    }
}
