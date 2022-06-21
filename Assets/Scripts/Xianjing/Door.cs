using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door instance;
    Animator anim;
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


    void Start()
    {
        anim = GetComponent<Animator>();
       
    

    }
    public void Open()
    {
        anim.SetBool("isEntered",true);
        AudioManager.instance.PlaySound("Doortie",transform.position);
       
    }
  
}
