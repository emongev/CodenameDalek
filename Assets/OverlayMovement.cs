using UnityEngine;
using System.Collections;

public class OverlayMovement : MonoBehaviour {

	public MovementLover movementLover;

	private Vector3 _initialPosition;

	[Range(0,2)]
	public float multiplier = 1f;

	// Use this for initialization
	void Start () {
		_initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(movementLover != null)
		{
			transform.position = _initialPosition + new Vector3(movementLover.GetDistanceFromInitial() * multiplier, 0f, 0f);
		}
	}
}
