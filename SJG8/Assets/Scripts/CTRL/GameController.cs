using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController :MonoBehaviour
{
  //是否清理完毕
    [HideInInspector]
    public bool isClear;
    //是否失败
    [HideInInspector]
    public bool isLose;
    //是否暂停
    [HideInInspector]
    public bool isPause;

    [HideInInspector]
    public  int CurrScore;

    private CanvasGroup PausePanel;

    private GameObject PauseButton;

    [HideInInspector]
    public AudioManger audioManger;

    [HideInInspector]
    public AudioSource BGM;

    // Start is called before the first frame update
    private void Awake()
    {
        audioManger = AudioManger.Instance;
    }

    void Start()
    {
     
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