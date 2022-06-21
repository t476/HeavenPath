using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
 
   void Start()
   {
        
   
   }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            //调用门打开GameManager.PlayerWon();
            GameManager.instance.animMe();
        }
    }

}
