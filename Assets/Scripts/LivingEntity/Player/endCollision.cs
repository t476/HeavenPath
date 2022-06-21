using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //µ÷ÓÃqqbot
            Debug.Log("qsy:hhh");
           switch(GameManager.instance.loadSense)
            {
                case 2:
                    QQBotHttps.instance.SendSpecificMessages(1);
                    break;
                case 3:
                    QQBotHttps.instance.SendSpecificMessages(3);
                    break;
                case 4:
                    QQBotHttps.instance.SendSpecificMessages(4);
                    break;
            }
            Application.Quit();
        }
    }
}
