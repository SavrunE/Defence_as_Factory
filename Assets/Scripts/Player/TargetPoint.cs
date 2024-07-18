using UnityEngine;

public class TargetPoint : MonoBehaviour
{
	[SerializeField] private Enemy _enemy;
	public Enemy enemy => _enemy;
	public Vector3 position => transform.position;

	private void Awake()
	{

	}
}
