using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
	public Rigidbody2D playerRigidbody;

	public float moveSpeed = 2.0f;
	public float jumpImpulse = 40.0f;
	public Vector2 downDirection;
	public LayerMask groundLayer;
	public float groundRaycastDistance = 3.0f;

	public bool debugIsGrounded;
	public Vector2 debugMoveDirection;

	private void Update()
	{
		debugIsGrounded = Physics2D.Raycast( playerRigidbody.position, downDirection, groundRaycastDistance, groundLayer.value ).transform != null;

		if( Input.GetButtonDown( "Jump" ) )
		{
			var hit = Physics2D.Raycast( playerRigidbody.position, downDirection, groundRaycastDistance, groundLayer.value );
			if( hit.transform != null )
			{
				playerRigidbody.AddForce( downDirection * ( -jumpImpulse ), ForceMode2D.Impulse );
			}
		}
	}

	private void FixedUpdate()
	{
		float move = Input.GetAxis( "Horizontal" );

		var moveDirection = new Vector2( -downDirection.y, downDirection.x );
		debugMoveDirection = moveDirection;

		playerRigidbody.AddForce( moveDirection * move, ForceMode2D.Impulse );
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine( transform.position, transform.position + ( Vector3 ) downDirection * groundRaycastDistance );
	}
}
