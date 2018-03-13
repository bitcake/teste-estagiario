using UnityEngine;

public sealed class Planet : MonoBehaviour
{
	public float gravityPull = 10.0f;

	public Vector3 GetGravityVector( Vector2 position )
	{
		Vector3 gravityVector = ( Vector2 ) transform.position - position;
		float sqrDistance = gravityVector.sqrMagnitude;

		return gravityVector.normalized * ( gravityPull / sqrDistance );
	}
}
