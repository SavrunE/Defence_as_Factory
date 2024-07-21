using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] private Text _text;

	public void UpdatePlayerHealth(int hp)
    {
		_text.text = hp.ToString();
	}
}
