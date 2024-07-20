using UnityEngine;

public class EnemyFinish : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<TargetPoint>(out TargetPoint tp))
		{
			_playerHealth.LoseHp();
			tp.enemy.Delete();
			tp.Deactivate();
		}
	}
}
