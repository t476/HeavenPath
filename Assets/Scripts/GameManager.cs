using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //todo奖励代码挂钩
    //人物死亡重置
    //当energyBar归0，触发上升阶梯
    public static GameManager instance;
    public bool playerCanJump;
    public int state;
    [Header("镜头切换有关")]
    public GameObject guoduImage;
    Animator anim;
    public float time = 1;
    public int deathNum;


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
        anim = guoduImage.GetComponent<Animator>();
        PlayerDie();

    }
    public void PlayerDie()
    {
        deathNum++;
        anim.enabled = true;
        Invoke("Death",time);
        anim.SetBool("Guodu", true);
        
    }
    public void Death()
    {
        PlayerEnergy.instance.ep = PlayerEnergy.instance.maxEp;
        EnergyBar.instance.UpdateEp();
        PlayerController.instance.gameObject.transform.position = new Vector3(0, 0, 0);

    }
    public void GuoduEnd()
    {
        anim.SetBool("Guodu", false);
        anim.enabled = false;
    }
    public void UpdateState()
    {
        state++;
        StartCoroutine(UpdateStateCo());
    }
    IEnumerator UpdateStateCo()
    {
        if (state == 1)
        {
            playerCanJump = true;
        }
        yield return null;
    }





}
