using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
	public Rigidbody2D playerRigidbody;

	public float moveSpeed = 2.0f;
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
		downDirection.Normalize();

		playerRigidbody.velocity = downDirection * move;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Vector3 gravityDirection = Quaternion.Euler( 0.0f, 0.0f, playerRigidbody.rotation ) * Vector3.down;
		Gizmos.DrawLine( transform.position, transform.position + gravityDirection * groundRaycastDistance );
	}
}
