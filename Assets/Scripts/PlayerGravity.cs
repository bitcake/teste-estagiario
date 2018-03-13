using UnityEngine;

public sealed class PlayerGravity : MonoBehaviour
{
	public PlayerController controller;
	public Rigidbody2D playerRigidbody;
	public Collider2D playerCollider;
	public Planet[] planets;

	private void FixedUpdate()
	{
		Vector3 maxGravityVector = Vector3.zero;

		foreach( var planet in planets )
		{
			var gravityVector = planet.GetGravityVector( playerCollider );
			if( gravityVector.sqrMagnitude > maxGravityVector.sqrMagnitude )
				maxGravityVector = gravityVector;
		}

		playerRigidbody.AddForce( maxGravityVector );

		controller.downDirection = maxGravityVector.normalized;
	}
}
