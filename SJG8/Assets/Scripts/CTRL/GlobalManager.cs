using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GlobalManager 
{
    [Header("加载关卡方式")]
    public static LoadMode loadLevelMode=LoadMode.Load;
    //当前场景
    public static string currScene;
 
    static GlobalManager()
    {
        currScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

 
}
