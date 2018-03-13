using UnityEngine;

public sealed class PlayerGravity : MonoBehaviour
{
	public PlayerController controller;
	public Rigidbody2D playerRigidbody;
	public Planet planet;

	private void FixedUpdate()
	{
		var gravityVector = planet.GetGravityVector( playerRigidbody.position );

		playerRigidbody.AddForce( gravityVector );
		//playerRigidbody.rotation = Vector2.SignedAngle( Vector2.down, gravityVector );

		controller.downDirection = new Vector2( -gravityVector.y, gravityVector.x ).normalized;
	}
}
