using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public bool facingRight = true;
	public bool canJump = false;
	private bool grounded = false;

	public float maxSpeed = 5f;
	public float moveForce = 5f;
	public float jumpForce = 5f;

	private Rigidbody2D rigid;
	private Animator anim;

	public Transform groundCheck;

	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		anim.SetBool("Ground", grounded);

		if(Input.GetButtonDown("Jump") && grounded)
		{
			canJump = true;
			anim.SetBool("Ground", false);
		}
	}

	void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");

		anim.SetFloat("Speed", Mathf.Abs(horizontal));
		anim.SetFloat("vSpeed", rigid.velocity.y);

		if(horizontal * rigid.velocity.x < maxSpeed)
		{
			rigid.AddForce(Vector2.right * horizontal * moveForce);
		}

		if(Mathf.Abs(rigid.velocity.x) > maxSpeed)
		{
			rigid.velocity = new Vector2(Mathf.Sign(rigid.velocity.x) * maxSpeed, rigid.velocity.y);
		}

		if(horizontal > 0 && !facingRight)
		{
			Flip();
		}
		else if(horizontal < 0 && facingRight)
		{
			Flip();
		}

		if(canJump)
		{
			rigid.AddForce(new Vector2(0, jumpForce));

			canJump = false;
		}
	}

	void Flip()
	{
		facingRight = !facingRight;

		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
