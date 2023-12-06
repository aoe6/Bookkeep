using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    public string sceneToLoad;

    public void changeScene(){
        SceneManager.LoadScene(sceneToLoad);
    }
}
