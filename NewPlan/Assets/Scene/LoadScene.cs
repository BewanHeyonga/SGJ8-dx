using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public enum LoadMode
{
    Load,
    LoadAsyncScene
}
public class LoadScene : MonoBehaviour
{
    /// <summary>
    /// 退出游戏
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
    /// <summary>
    /// 加载
    /// </summary>
    /// <param name="SceneName"></param>
    public void Load(string SceneName)
    {
        
        Time.timeScale = 1;
        //告知全局管理器下一场景
        GlobalManager.currScene = SceneName;
        StartCoroutine(LoadWaitMusic(SceneName));
    }
    IEnumerator LoadWaitMusic(string SceneName)
    {
        AudioManger.Instance.PlayAudio("button");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneName);
    }

    /// <summary>
    /// 异步加载
    /// </summary>
    /// <param name="SceneName"></param>
    public void LoadAsyncScene(string SceneName)
    {
        
        Time.timeScale = 1;
        //告知全局管理器下一场景
        GlobalManager.currScene = SceneName;
        StartCoroutine(LoadWaitMusic("Transition"));
    }

    /// <summary>
    /// 重新加载，默认没有加载过程
    /// </summary>
    public void Reload()
    {
        Load(GlobalManager.currScene);
    }
    /// <summary>
    /// 如果为true,就有加载画面，默认为false
    /// </summary>
    /// <param name="isLoading"></param>
    public void Reload(bool isLoading)
    {
        if (isLoading)
        {
            LoadAsyncScene(GlobalManager.currScene);
        }
        else
        {
            Load(GlobalManager.currScene);
        }
    }

    //加载下一关卡
    public void LoadNextLevel()
    {
        //先获取下一关卡名称
        string SceneName = GlobalManager.GetNextLevel();
        if (SceneName == "Index Out")
        {//处理超界
            return;
        }
        else
        {//加载关卡
            if (GlobalManager.loadLevelMode == LoadMode.Load)
            {
                Load(SceneName);
            }
            else if (GlobalManager.loadLevelMode == LoadMode.LoadAsyncScene)
            {
                LoadAsyncScene(SceneName);
            }
        }
    }
}

