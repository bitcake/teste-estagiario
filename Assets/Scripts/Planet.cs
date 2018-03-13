using UnityEngine;

public sealed class Planet : MonoBehaviour
{
	public float gravityPull = 10.0f;
	public Collider2D planetCollider;

	public Vector3 GetGravityVector( Collider2D otherCollider )
	{
		var distance = planetCollider.Distance( otherCollider );
		var gravityVector = distance.normal * ( distance.distance + 1.0f );

		//gravityVector = ( Vector2 ) transform.position - ( Vector2 ) otherCollider.transform.position;
		//gravityVector = gravityVector.normalized * ( distance.distance + 1.0f );

		float sqrDistance = gravityVector.sqrMagnitude;

		return gravityVector.normalized * ( gravityPull / sqrDistance );
	}
}
