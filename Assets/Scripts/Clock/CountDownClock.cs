using UnityEngine;
using UnityEngine.UI;

public class CountDownClock : MonoBehaviour
{
    public static CountDownClock instance;

    //表盘背景，用于配合指针表示倒计时范围
    public Image clockBackground;

    //两个表盘指针，max是大的那个，current是小的那个
    public GameObject maxTimeHand;

    public GameObject currentTimeHand;

    //Unix系统上，time是毫秒单位的
    //但是在Windows上是以秒为单位的，在hzw电脑上可能会有问题

    //倒计时时间上限，即表盘转一周需要maxGameTime秒，按照直觉这里设置60
    public int maxGameTime;

    //警告的时间范围，剩余时间小于alertTime秒就会触发alert
    public int alertTime;

    //需要倒计时的时间，即会倒数gameTime秒
    public int gameTime;

    public bool timeIsOut;
    public float currentTimeFloat = 0f;

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
        //表盘的填充，配合表针表现倒数时间的范围
        //fillAmount是一个[0, 1]的float值，表示变盘的展示比例
        //配合Top属性的话，这个范围是从0点开始的顺时针范围
        clockBackground.fillAmount = (float)gameTime / maxGameTime;

        //maxTimeAngle是角度制的范围，单位为度，用于设置max大表针的位置
        int maxTimeAngle = (int)(gameTime * 360) / maxGameTime;
        maxTimeHand.transform.eulerAngles = new Vector3(0, 0, -maxTimeAngle);
    }

    private void Update()
    {
        currentTimeFloat += Time.deltaTime;
        //currentTimeAngle是角度制的范围，单位为度，用于设置current小表针的位置
        //currentTimeFloat是从场景加载运行到现在的时间，单位是秒
        float currentTimeAngle = (float)((currentTimeFloat * 360) / maxGameTime);
        currentTimeHand.transform.eulerAngles = new Vector3(0, 0, -currentTimeAngle);

        Alert();
        CheckGameOver();
    }

    private void Alert()
    {
        //检查剩余时间是否小于alertTime，如果小于就把表盘设置为红色
        if (gameTime - (int)currentTimeFloat <= alertTime)
        {
            //color的Vector4的四个值是(red, green, blue, alpha)
            //各个值的范围是[0,1]的float，alpha是透明度
            currentTimeHand.GetComponent<Image>().color = new Vector4(1, 0, 0, 1);
            clockBackground.color = new Vector4(1, 0, 0, 1);
        }
    }

    private void CheckGameOver()
    {
        if (currentTimeFloat >= gameTime)
        {
            timeIsOut = true;
        }
    }
}