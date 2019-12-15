using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//全局管理
public class Level
{
    public string levelName;
    //是否解锁
    public bool isUnlock;
    //收集物数目
    public int CollectionNum;
    //限制时间
    public float LimitedTime;

    public Level(string name,bool isUn,int num,float time)
    {
        levelName = name;
        isUnlock = isUn;
        num = CollectionNum;
        LimitedTime = time;
    }
}
public static class GlobalManager 
{
    [Header("加载关卡方式")]
    public static LoadMode loadLevelMode=LoadMode.LoadAsyncScene;
    //当前场景
    public static string currScene;
     
    //关卡
    public static Level currLevel;
    public static List<Level> levelLists;

    static GlobalManager()
    {
        currScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

  
        levelLists = new List<Level>();

        //关卡
        Level level1= new Level("Level1",false,3,180f);

        levelLists.Add(level1);
    }

    public static string GetNextLevel()
    {
        int index = levelLists.IndexOf(currLevel);
        if (index >levelLists.Count)
        {
            //超出右界
            return "Index Out";
        }
        else
        {
            index += 1;
            currLevel = levelLists[index];
            return currLevel.levelName;
        }
    }

 
}
