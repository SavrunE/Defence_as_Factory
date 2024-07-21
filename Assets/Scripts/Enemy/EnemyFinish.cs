using UnityEngine;

public class EnemyFinish : MonoBehaviour
{
    [SerializeField] private Game _game;

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<TargetPoint>(out TargetPoint tp))
		{
			_game.TakeDamage();
			tp.enemy.Recycle();
			tp.Deactivate();
		}
	}
}
