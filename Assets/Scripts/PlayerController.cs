using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int moveSpeed;
	public int jumpHeight;

	public Transform groundPoint;
	public float radius;
	public LayerMask groundMask;

	bool isGrounded;
	Rigidbody2D rb2D;


	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}


	void Update () {
		Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2D.velocity.y);
		rb2D.velocity = moveDir;

		isGrounded = Physics2D.OverlapCircle(groundPoint.position, radius, groundMask);

		if(Input.GetAxisRaw("Horizontal") == 1){
			transform.localScale = new Vector3(1, 1, 1);
		} else if(Input.GetAxisRaw("Horizontal") == -1){
			transform.localScale = new Vector3(-1, 1, 1);
		}

		if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
			rb2D.AddForce(new Vector2(0, jumpHeight));
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(groundPoint.position, radius);
	}
}
