using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	private int _health;
	[SerializeField] private Text _text;

	public void SetHp(int hp)
    {
		_health = hp;
		_text.text = _health.ToString();
	}

	public void LoseHp()
	{
		_text.text = _health--.ToString();
	}
}
