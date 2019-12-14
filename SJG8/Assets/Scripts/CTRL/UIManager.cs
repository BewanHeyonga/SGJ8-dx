
using UnityEngine;
using UnityEngine.UI;
//UI管理
public class UIManager 
{
    #region Singleton
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }
    #endregion

    //更新分数文本
    public void ChangeText(Text text, string str)
    {
        text.text = str;
    }

    //隐藏界面
    public void Hide(CanvasGroup group)
    {
        group.alpha = 0;
        group.interactable = false;
        group.gameObject.SetActive(false);
    }

    //显示界面
    public void UnHide(CanvasGroup group)
    {
        group.gameObject.SetActive(true);
        group.alpha = 1;
        group.interactable = true;
    }
}
