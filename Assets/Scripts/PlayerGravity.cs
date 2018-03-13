using UnityEngine;

public sealed class PlayerGravity : MonoBehaviour
{
	public PlayerController controller;
	public Rigidbody2D playerRigidbody;
	public Transform pivotTransform;
	public Planet planet;

	private void FixedUpdate()
	{
		var gravityVector = planet.GetGravityVector( playerRigidbody.position );

		playerRigidbody.AddForce( gravityVector );

		//playerRigidbody.rotation = Vector2.SignedAngle( Vector2.down, gravityVector );
		pivotTransform.rotation = Quaternion.Euler( 0.0f, 0.0f, Vector2.SignedAngle( Vector2.down, gravityVector ) );

		controller.downDirection = gravityVector.normalized;
	}
}
