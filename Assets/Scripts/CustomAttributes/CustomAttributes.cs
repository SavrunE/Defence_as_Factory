using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct FloatRange
{
    [SerializeField] private float _min, _max;
    public float min => _min;
    public float max => _max;

    public float randomValueInRange
    {
        get => Random.Range(_min, _max);
    }

    public FloatRange(float value)
    {
        _min = _max = value;
    }

    public FloatRange(float min, float max)
    {
        _min = min;
        _max = max;
    }
}

public class FloatRangeSliderAttribute : PropertyAttribute
{
    public float Min { get; private set; }
    public float Max { get; private set; }

    public FloatRangeSliderAttribute(float min, float max)
    {
        Min = min;
        Max = max < min ? min : max;
    }   
}

[Serializable]
public struct IntRange
{
	[SerializeField] private int _min, _max;
	public int min => _min;
	public int max => _max;

	public int randomValueInRange
	{
		get => Random.Range(_min, _max);
	}

	public IntRange(int value)
	{
		_min = _max = value;
	}

	public IntRange(int min, int max)
	{
		_min = min;
		_max = max;
	}
}

public class IntRangeSliderAttribute : PropertyAttribute
{
	public int Min { get; private set; }
	public int Max { get; private set; }

	public IntRangeSliderAttribute(int min, int max)
	{
		Min = min;
		Max = max < min ? min : max;
	}
}