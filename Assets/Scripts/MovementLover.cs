using UnityEngine;
using System.Collections;
using InControl;

public class MovementLover : MonoBehaviour {

	public const float GROUNDED_DISTANCE = 0.6f;
	public const float JUMPING_VERTICAL_VELOCITY = 7f;
	public const float MOVING_HORIZONTAL_VELOCITY = 7f;

	public bool invertedMovement = false;

	private Vector3 _initialPosition;
	private bool _isGrounded = false;

	// Use this for initialization
	void Start()
	{
		_initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update()
	{
		UpdateGrounded();

		if(InputManager.ActiveDevice.Action1.WasPressed)
		{
			Jump();
		}

		Move(InputManager.ActiveDevice.Direction.X);
	}

	private void Jump()
	{
		if(_isGrounded)
		{
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, JUMPING_VERTICAL_VELOCITY, rigidbody.velocity.z);
		}
	}

	private void Move(float movementfloat)
	{
		rigidbody.velocity = new Vector3(MOVING_HORIZONTAL_VELOCITY * movementfloat, rigidbody.velocity.y, rigidbody.velocity.z);
	}

	private void UpdateGrounded()
	{
		_isGrounded = false;
		Vector3 direction = new Vector3(0f, -1f, 0f);
		
		Debug.DrawRay(transform.position,direction*GROUNDED_DISTANCE,Color.green);

		RaycastHit hit = new RaycastHit();

		if(Physics.Raycast(transform.position,direction,out hit,GROUNDED_DISTANCE))
		{
			if(hit.collider.tag == "MovementBlocker")
			{
				_isGrounded = true;
			}
		}
	}

	public float GetDistanceFromInitial()
	{
		return Vector3.Distance(_initialPosition, transform.position);
	}
}
