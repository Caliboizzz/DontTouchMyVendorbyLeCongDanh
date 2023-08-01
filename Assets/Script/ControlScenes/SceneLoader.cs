using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string SceneMainMenuName;
    public string SceneNextActName;
    public GameObject LoadingPanel;
    public GameObject QuitPanel;

    int Saved_scene;
    int Scene_index;

    public void LoadMainMenuScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneMainMenuName);
    }

    public void LoadNextActScene()
    {
        Time.timeScale = 1f;
        // SceneManager.LoadScene(SceneNextActName);
        StartCoroutine(LoadNextActSceneAsync());
    }


    IEnumerator LoadNextActSceneAsync()
    {

        LoadingPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneNextActName, LoadSceneMode.Single);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
        Scene scene = SceneManager.GetSceneByName(SceneNextActName);
        if (scene != null && scene.isLoaded)
        {
            SceneManager.SetActiveScene(scene);
        }

    }

    public void LoadSaveScene()
    {
        Time.timeScale = 1f;
        // SceneManager.LoadScene(SceneNextActName);
        StartCoroutine(LoadSaveSceneAsync());
    }

    IEnumerator LoadSaveSceneAsync()
    {
        Saved_scene = PlayerPrefs.GetInt("Saved");
        LoadingPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        if (Saved_scene != 0)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(Saved_scene, LoadSceneMode.Single);
            while (!asyncOperation.isDone)
            {
                yield return null;
            }
            Scene scene = SceneManager.GetSceneByBuildIndex(Saved_scene);
            if (scene != null && scene.isLoaded)
            {
                SceneManager.SetActiveScene(scene);
            }
        }else{
            StartCoroutine(LoadNextActSceneAsync());
        }


    }

    public void Save(){
        Scene_index=SceneManager.GetActiveScene().buildIndex+1;
        PlayerPrefs.SetInt("Saved",Scene_index);
        PlayerPrefs.Save();
    }


    public void ShowQuitPanel()
    {
        QuitPanel.SetActive(true);
    }
    public void HideQuitPanel()
    {
        QuitPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
