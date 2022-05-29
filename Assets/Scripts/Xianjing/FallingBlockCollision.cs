using UnityEngine;

public class FallingBlockCollision : MonoBehaviour
{
	public Rigidbody2D rigidBody;
	BoxCollider2D box;
	//AudioSource audioSource;
	LayerMask groundMask;
	int groundLayer;


	void Start()
	{
		//rigidBody = GetComponent<Rigidbody2D>();//这么写为什么不对捏
		box = GetComponent<BoxCollider2D>();
		//audioSource = GetComponent<AudioSource>();

	}

	public void Fall()
	{
		Debug.Log("fall");
		rigidBody.bodyType = RigidbodyType2D.Dynamic;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.CompareTag("Ground"))
			return;

		Vector3 pos = rigidBody.position;
		RaycastHit2D hit;

		hit = Physics2D.Raycast(pos, Vector2.down, 1f, groundMask);//不用这个改用设置static collider也行吧
		pos.y = hit.point.y + .5f;
		transform.position = pos;

		box.usedByComposite = true;//碰撞体合并
		Destroy(rigidBody);

		//audioSource.Play();
	}
}
