using UnityEngine;

public sealed class Planet : MonoBehaviour
{
	public float gravityPull = 10.0f;
	public Collider2D planetCollider;

	public Vector3 debugPoint;
	public Vector3 debugGravity;

	public Vector3 GetGravityVector( Collider2D otherCollider )
	{
		var distance = planetCollider.Distance( otherCollider );
		var gravityVector = distance.normal * ( distance.distance + 1.0f );
		//Vector3 gravityVector = ( Vector2 ) transform.position - position;

		float sqrDistance = gravityVector.sqrMagnitude;

		debugPoint = distance.pointA;
		debugGravity = distance.normal;

		return gravityVector.normalized * ( gravityPull / sqrDistance );
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine( debugPoint, debugPoint + debugGravity );
	}
}
