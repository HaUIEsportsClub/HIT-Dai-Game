using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : Singleton<LoadSceneManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        LoadScenePro(sceneName);
    }

    public void ReloadScene()
    {
        var curSceneName = SceneManager.GetActiveScene().name;
        LoadScenePro(curSceneName);
    }
    
    private void LoadScenePro(string sceneName)
    {
        StartCoroutine(IELoadScene(sceneName));
    }

    private IEnumerator IELoadScene(string sceneName)
    {
        //yield return new WaitForSeconds(0.5f);
        TransitionFx.Instance.StartLoadScene();
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        TransitionFx.Instance.EndLoadScene();
        //yield return new WaitForSeconds(0.5f);
    }
}