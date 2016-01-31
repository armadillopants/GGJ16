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
	public float groundRadius = 0.2f;

	private Rigidbody2D rigid;
	private Animator anim;

	public Transform groundCheck;

	private float lastFootStepPlayed;
	public float walkTimer;

	public AudioClip footstep;
	public AudioClip jump;
	public AudioClip landed;

	private AudioSource source;

	public bool canMove = true;
	private bool wasGrounded;

	// Use this for initialization
	void Start () 
	{
		rigid = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Jump"))
		{
			canJump = true;
		}
	}

	void FixedUpdate()
	{
		if(canMove)
		{
			float horizontal = Input.GetAxis("Horizontal");

			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius,  1 << LayerMask.NameToLayer("Ground"));
			anim.SetBool("Ground", grounded);

			if(grounded)
			{
				anim.SetFloat("Speed", Mathf.Abs(horizontal));
			}
			anim.SetFloat("vSpeed", rigid.velocity.y);

			if(!wasGrounded && grounded)
			{
				source.PlayOneShot(landed, 0.5f);
			}

			rigid.velocity = new Vector2(horizontal * maxSpeed, rigid.velocity.y);

			if(grounded && Time.time - lastFootStepPlayed > walkTimer)
			{
				if(horizontal > 0 || horizontal < 0)
				{
					source.PlayOneShot(footstep, 0.2f);
					lastFootStepPlayed = Time.time;
				}
			}

			if(horizontal > 0 && !facingRight)
			{
				Flip();
			}
			else if(horizontal < 0 && facingRight)
			{
				Flip();
			}

			if(grounded && canJump)
			{
				anim.SetBool("Ground", false);
				rigid.AddForce(new Vector2(0, jumpForce));
				source.PlayOneShot(jump, 0.7f);
			}

			canJump = false;

			wasGrounded = grounded;
		}
		else
		{
			anim.SetFloat("Speed", 0);
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
