using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RotatingObstacle : MonoBehaviour
{
    [SerializeField] private float _rotation = 1f;

    private int _randomRotate;

    private void Start()
    {   // Рандом генератор
        _randomRotate = Random.Range(0, 2);
    }

    private void Update()
    {   // Вращаем вперед или назад
        transform.Rotate(_randomRotate == 0 ? Vector3.back : Vector3.forward, _rotation);
    }
}