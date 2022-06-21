using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
     [Header("场景管理")]
    public int loadSense;
    public int finishIndex;
    Animator animMine;




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
        animMine = GetComponent<Animator>();
        anim = guoduImage.GetComponent<Animator>();
        
        

    }
    private void Update()
    {
        if (loadSense != 0)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("inputk");
                //直接先这样
                SceneManager.LoadScene(loadSense);

            }
        }
    }
    public void animMe()
    {
        
        animMine.SetBool("inEntered", true);
        AudioManager.instance.PlaySound("Door", transform.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
                 Debug.Log("woshi trigger");
           
                if (CountDownClock.instance.timeIsOut == false)
            {
                    Debug.Log("woshi 2chagnjing");
                loadSense = 2;
                }
            else
            {
                //看有没有拿到花
                if (finishIndex == 3)
                {
                    loadSense = 3;
                }
                if (finishIndex < 3)
                {
                    loadSense = 4;
                }
            }
            
        }
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
