using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    public Enemy enemy { get; private set; }
    public Vector3 position => transform.position;

    private void Awake()
    {
        
    }
}
