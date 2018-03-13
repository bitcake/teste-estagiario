using UnityEngine;

public sealed class Planet : MonoBehaviour
{
	public float gravityPull = 10.0f;
	public Collider2D planetCollider;

	public Vector3 GetGravityVector( Collider2D otherCollider )
	{
		var distance = planetCollider.Distance( otherCollider );
		var gravityVector = distance.normal * distance.distance;
		//Vector3 gravityVector = ( Vector2 ) transform.position - position;

		float sqrDistance = gravityVector.sqrMagnitude;

		return gravityVector.normalized * ( gravityPull / sqrDistance );
	}
}
