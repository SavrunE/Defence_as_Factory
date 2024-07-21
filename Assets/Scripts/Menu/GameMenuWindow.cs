using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class GameMenuWindow : MonoBehaviour
{
	[SerializeField] private Button _restartButton;
	[SerializeField] private Text _tittle;

	private Canvas _canvas;

	public Action onRestartClicked;

	private void Awake()
	{
		_canvas = GetComponent<Canvas>();
		_canvas.enabled = false;
		_restartButton.onClick.AddListener(OnRestartClicked);
	}

	public void Show(GameResultType result)
	{
		OnPaused(true);
		switch (result)
		{
			case GameResultType.Victory:
				_tittle.text = "Победа";
				break;
			case GameResultType.Defeat:
				_tittle.text = "Поражение";
				break;
		}
		_restartButton.interactable = false; //this is necessary to correct button click, another way is double click on the button (unity bug)
		_canvas.enabled = true;
		_restartButton.interactable = true;
	}

	private void OnRestartClicked()
	{
		OnPaused(false);
		onRestartClicked?.Invoke();
		_canvas.enabled = false;
	}

	private void OnPaused(bool isPaused)
	{
		Time.timeScale = isPaused ? 0f : 1f;
	}
}

