using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuManager : MonoBehaviour
{

    public void NameEntered(string text)
    {
        // add code here to handle when a color is selected
        MenuGameManager.Instance.nameText = text;
    }

    public void StartNew()
    {
        MenuGameManager.Instance.SaveName();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }



}
