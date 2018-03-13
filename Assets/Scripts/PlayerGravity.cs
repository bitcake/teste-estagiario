using UnityEngine;

public sealed class PlayerGravity : MonoBehaviour
{
	public PlayerController controller;
	public Rigidbody2D playerRigidbody;
	public Collider2D playerCenterCollider;

	private Planet[] planets;

	private void Start()
	{
		planets = FindSceneObjectsOfType( typeof( Planet ) ) as Planet[];
	}

	private void FixedUpdate()
	{
		var planet = planets[0];
		Vector3 gravityVector = planet.GetGravityVector( playerCenterCollider );

		playerRigidbody.AddForce( gravityVector );
		controller.downDirection = gravityVector.normalized;
	}
}
