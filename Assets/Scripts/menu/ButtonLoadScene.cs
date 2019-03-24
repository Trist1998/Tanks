using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoadScene : MonoBehaviour
{
    public string sceneName;
    void OnMouseUp()
    {
        SceneManager.LoadScene(sceneName);
    }
}
