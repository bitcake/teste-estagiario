using UnityEngine;

public sealed class Planet : MonoBehaviour
{
	public float gravityPull = 10.0f;
	public Collider2D planetCollider;

	public Vector3 GetGravityVector( Collider2D otherCollider )
	{
		var gravityVector = ( Vector2 ) transform.position - ( Vector2 ) otherCollider.transform.position;
		float distance = Vector2.Distance( transform.position, otherCollider.transform.position );

		return gravityVector.normalized * ( gravityPull / ( distance * distance ) );
	}
}
