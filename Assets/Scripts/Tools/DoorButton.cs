using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //��һ���������ˣ���������֡���Ͽ���
            anim.SetBool("isEntered", true);

        }
    }
    public void DoorOpen()
    {
        Door.instance.Open();
    }
}
