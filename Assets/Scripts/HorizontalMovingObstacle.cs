using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HorizontalMovingObstacle : MonoBehaviour
{
    [SerializeField] private float _duration = 1f;
    [SerializeField] private float _moveDistance = 2f;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private int _randomWay;

    private void Start()
    {
        // Определяем начальную и конечную позиции влево и вправо от текущей позиции объекта
        _startPosition = transform.position - new Vector3(_moveDistance, 0f, 0f);
        _endPosition = transform.position + new Vector3(_moveDistance, 0f, 0f);

        _randomWay = Random.Range(0, 2);
    }

    private void Update()
    {
        // Используем Mathf.PingPong для создания значения между 0 и 1
        float pingPongValue = Mathf.PingPong(Time.time * _duration, _moveDistance) / _moveDistance;

        // Используем Vector3.Lerp для интерполяции между начальной и конечной позициями
        Vector3 newPositionInStart = Vector3.Lerp(_startPosition, _endPosition, pingPongValue);
        Vector3 newPositionInEnd = Vector3.Lerp(_endPosition, _startPosition, pingPongValue);

        // Применить новую позицию к объекту
        transform.position = _randomWay == 0 ? newPositionInStart : newPositionInEnd;
    }
}