using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31;

public class PlayerController : MonoBehaviour {

	public CharacterController2D.CharacterCollisionState2D flags;
	public float moveSpeed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;

	public bool isGrounded;
	public bool isJumping;

	//Private variables
	private Vector3 _moveDirection = Vector3.zero;
	private CharacterController2D _characterController;

	// Use this for initialization
	void Start () {
		_characterController = GetComponent<CharacterController2D>();
		isGrounded = false;
	}
	
	// Update is called once per frame
	void Update () {
		_moveDirection.x = Input.GetAxis("Horizontal");
		_moveDirection.x *= moveSpeed;

		if(isGrounded){
			_moveDirection.y = 0;

			if(Input.GetButtonDown("Jump")){
				_moveDirection.y = jumpSpeed;
				isJumping = true;
			}
		}
		else{

		}
		_moveDirection.y -= gravity * Time.deltaTime;

		_characterController.move(_moveDirection * Time.deltaTime);
		flags =_characterController.collisionState;

		isGrounded = flags.below;
		if(flags.above){
			_moveDirection.y = gravity * Time.deltaTime;
		}
	}
}
