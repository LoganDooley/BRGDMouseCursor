using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchScene : MonoBehaviour
{

    // This is a basic script for changing scenes, you can just add it to a
    // scene, and then you can just externally call on ChangeScene() to change
    // the scene

    public string sceneName = "MichaelScene";

    public void ChangeScene() {
        SceneManager.LoadScene(this.sceneName);
    }
}
