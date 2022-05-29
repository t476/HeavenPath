using UnityEngine;

public class FallingBlock : MonoBehaviour
{
	public FallingBlockCollision block;

	//Animator anim;
	BoxCollider2D box;
	//AudioSource audioSource;
	

	void Start()
	{
		//anim = GetComponent<Animator>();
		box = GetComponent<BoxCollider2D>();
		//audioSource = GetComponent<AudioSource>();


		//fallParamID = Animator.StringToHash("Activate");
		//Fall();
	}
	//动画事件调用
	public void Fall()
	{
		
		block.Fall();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Player"))
			return;
		Fall();
		box.enabled = false;
		//audioSource.Play();//这里是加了动画
		//anim.SetTrigger(fallParamID);
	}


}
