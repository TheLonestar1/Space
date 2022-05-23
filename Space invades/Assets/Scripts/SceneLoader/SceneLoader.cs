using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string _sceneNameSaved;

    private readonly LevelNameData _levelName = new LevelNameData();

    private void Start()
    {
        if(!string.IsNullOrEmpty(_sceneNameSaved))
        {
            StartCoroutine(AddScene(_sceneNameSaved));
        }
    }
    public void Load()
    {
        if(!string.IsNullOrEmpty(_levelName.GetName()))
        {
            StartCoroutine(SceneController(_levelName.GetName()));
        }
    }
    
    private IEnumerator SceneController(string sceneName)
    {
        if(!string.IsNullOrEmpty(_sceneNameSaved))
        {
            Debug.Log(_sceneNameSaved);
            yield return StartCoroutine(RemoveOldScene());
            yield return StartCoroutine(UnloadResources());
        }
        _sceneNameSaved = sceneName;
        yield return StartCoroutine(AddScene(sceneName));
    }

    private IEnumerator AddScene(string name)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        while(!asyncOperation.isDone){
            yield return null;
        }
    }
    private IEnumerator RemoveOldScene()
    {
        AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(_sceneNameSaved);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }
    private IEnumerator UnloadResources()
    {
        AsyncOperation asyncOperation = Resources.UnloadUnusedAssets();
        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
