using UnityEngine;
using System.Collections;

public class PushGuy : Action 
{
	private Rigidbody2D rigid;

	public float force;

	void Start()
	{
		rigid = GetComponent<Rigidbody2D>();
	}

	public override void BadChoice ()
	{
		base.BadChoice();

		rigid.constraints = RigidbodyConstraints2D.None;
		rigid.constraints = RigidbodyConstraints2D.FreezeRotation;

		rigid.AddForce(new Vector2(force, 0f));
	}
}
