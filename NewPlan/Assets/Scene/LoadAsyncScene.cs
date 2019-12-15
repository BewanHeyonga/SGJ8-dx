using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//异步加载关卡
public class LoadAsyncScene : MonoBehaviour {

    // 目标进度
    float target = 0;
    // 异步对象
    AsyncOperation op = null;

    private float curTime=0;
    public float loadTime;

    private Slider slider;

    public string sceneName;
    void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        Debug.Log("开始LoadScene");

        sceneName = GlobalManager.currScene;
        op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;

        // 开启协程，开始调用加载方法
        StartCoroutine(processLoading());
    }

    bool isCompelate = false;
    // 加载进度
    IEnumerator processLoading()
    {
        while (!isCompelate)
        {
            curTime += Time.deltaTime;
            slider.value = curTime / loadTime;
            target = op.progress; // 进度条取值范围0~1
            if (target >= 0.9f && slider.value>=1f)
            {
                target = 1;
                isCompelate = true;
            }
            yield return 0;
        }

        yield return new WaitForSeconds(1f);
        op.allowSceneActivation = true;
    }
}
