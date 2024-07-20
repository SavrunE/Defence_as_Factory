using System;
using UnityEngine;

public class CharacterBorders : MonoBehaviour
{
	[SerializeField] private GameObject _topBorder;
	private Camera _mainCam;
	private float _camAspect;
	private Vector2 _horizontalBorders, _verticalBorders;

	public Action<Vector2, Vector2> onBordersChanged;

	private void Start()
	{
		_mainCam = Camera.main;
		_camAspect = _mainCam.aspect;
		ChangeBorders();
	}

	private void Update()
	{
		if (_mainCam.aspect != _camAspect)
		{
			_camAspect = _mainCam.aspect;
			ChangeBorders();
		}
	}

	private void ChangeBorders()
	{
		Vector3 bottomL = _mainCam.ViewportToWorldPoint(new Vector3(0, 0, _mainCam.nearClipPlane));
		Vector3 bottomR = _mainCam.ViewportToWorldPoint(new Vector3(1, 0, _mainCam.nearClipPlane));

		_horizontalBorders = new Vector2(bottomL.x, bottomR.x);
		_verticalBorders = new Vector2(bottomL.y, _topBorder.transform.localPosition.y);

		onBordersChanged?.Invoke(_horizontalBorders, _verticalBorders);
	}
}
