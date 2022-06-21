using UnityEngine;
using UnityEngine.UI;

//这个脚本将会放在【UI Canvas】游戏对象上 任务UI列表
public class QuestManager : MonoBehaviour
{   
    public static QuestManager instance;

    public GameObject[] questArray;

    //public GameObject questPanel;//打开关闭的控制

    public Text expText, goldText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UpdateQuestList();
        //questPanel.SetActive(false);
    }

    //这个方法将会在【领取好任务】【任务完成后】调用
    public void UpdateQuestList()
    {
       
    }



    public void UpdateUIText()
    {
       
    }
}
