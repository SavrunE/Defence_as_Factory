using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
	[SerializeField] protected SpawnPoint[] _spawnPoints;

	public Transform TakeRandomSpawnPoint()
	{
		var rnd = Random.Range(0, _spawnPoints.Length);
		return _spawnPoints[rnd].transform;
	}
}
