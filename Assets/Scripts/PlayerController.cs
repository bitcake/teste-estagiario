using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
	public Rigidbody2D playerRigidbody;
	public Transform pivotTransform;

	public float moveSpeed = 2.0f;
	public float maxMoveSpeed = 1.0f;
	public float jumpImpulse = 40.0f;
	public Vector2 downDirection;
	public LayerMask groundLayer;
	public float groundRaycastDistance = 3.0f;

	private void Update()
	{
		if( Input.GetButtonDown( "Jump" ) )
		{
			var hit = Physics2D.Raycast( playerRigidbody.position, downDirection, groundRaycastDistance, groundLayer.value );
			if( hit.transform != null )
				playerRigidbody.AddForce( downDirection * ( -jumpImpulse ), ForceMode2D.Impulse );
		}
	}

	private void FixedUpdate()
	{
		float move = Input.GetAxis( "Horizontal" );
		var moveDirection = new Vector2( -downDirection.y, downDirection.x );

		playerRigidbody.AddForce( moveDirection * move * moveSpeed, ForceMode2D.Impulse );

		//playerRigidbody.rotation = Vector2.SignedAngle( Vector2.down, gravityVector );
		pivotTransform.rotation = Quaternion.Euler( 0.0f, 0.0f, Vector2.SignedAngle( Vector2.down, downDirection ) );

		/*
		float horizontalVelocity = Vector2.Dot( playerRigidbody.velocity, moveDirection );
		float verticalVelocity = Vector2.Dot( playerRigidbody.velocity, downDirection );

		if( Mathf.Abs( horizontalVelocity ) > maxMoveSpeed )
			horizontalVelocity = Mathf.Sign( horizontalVelocity ) * maxMoveSpeed;

		playerRigidbody.velocity = new Vector2( horizontalVelocity, verticalVelocity );
		 */
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine( transform.position, transform.position + ( Vector3 ) downDirection * groundRaycastDistance );
	}
}
