using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController :MonoBehaviour
{

    public Level levelFile;
    [HideInInspector]
    private EnemyManager enemyManager;
  

    private float deltaTime=1f;
    public int currWaveNum=0;
    
    public Text progressText;
    #region Singleton
    private static GameController instance;
    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameController();
            }
            return instance;
        }
    }
    #endregion
    private void Awake()
    {
        instance = this;
        enemyManager = EnemyManager.Instance;
    }
    void Start()
    {
        
        StartCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {

        yield return new WaitForSeconds(1f);
        enemyManager.Spawn(0);
    }
    public void GoNextWave()
    {
        StartCoroutine(NextWave());
    }
    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(deltaTime);
        if (currWaveNum < levelFile.waves.Count-1)
        {
            print(currWaveNum + "currWaveNum," + levelFile.waves.Count + "levelFile.waves.Count");
            enemyManager.Enemies = enemyManager.spawnCtrl.Spawn(++currWaveNum);
            progressText.text = string.Format("Progress:{0}/{1}", (currWaveNum + 1), (levelFile.waves.Count));
        }
        else
        { print("Clear"); }
    }
    // 胜利，结算功能TODO
    public void Win()
    {
        StartCoroutine(WinCoroutine());
        
    }
    //失败
    public void Lose()
    {
        StartCoroutine(LoseCoroutine());
    }
    IEnumerator WinCoroutine()
    {
        yield return null;
    }
    //开始失败
    IEnumerator LoseCoroutine()
    {
        yield return null;
    }

}