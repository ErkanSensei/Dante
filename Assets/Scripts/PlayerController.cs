using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Animator animator;
	public int moveSpeed;
	public int jumpHeight;

	public Transform groundPoint;
	public float radius;
	public LayerMask groundMask;

	bool isGrounded;
	Rigidbody2D rb2D;


	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}


	void Update () {
		Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2D.velocity.y);
		rb2D.velocity = moveDir;
		//animator.GetBool("isWalking");


		isGrounded = Physics2D.OverlapCircle(groundPoint.position, radius, groundMask);

		if(Input.GetAxisRaw("Horizontal") == 1){
			transform.localScale = new Vector3(1, 1, 1);
		} else if(Input.GetAxisRaw("Horizontal") == -1){
			transform.localScale = new Vector3(-1, 1, 1);
		}
		//animator.SetBool ("isWalking", true);
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
			rb2D.AddForce(new Vector2(0, jumpHeight));
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(groundPoint.position, radius);
	}
}
