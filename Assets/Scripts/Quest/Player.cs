using System.Collections.Generic;
using UnityEngine;

//这个脚本添加在Player游戏对象上
public class Player : MonoBehaviour
{
    public static Player instance;

    public int exp, gold, itemAmount;

    //之后其他脚本就可以获得这个list了
    public List<Quest> questList = new List<Quest>();
    

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
       
    }

}
