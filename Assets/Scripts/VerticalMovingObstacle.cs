using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingObstacle : MonoBehaviour
{
    [SerializeField] private float _duration = 2f;
    [SerializeField] private float _moveDistance = 2f;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private float _currantTime;

    private void Start()
    {
        // Определяем начальную и конечную позиции влево и вправо от текущей позиции объекта
        _startPosition = transform.position - new Vector3(0f, _moveDistance, 0f);
        _endPosition = transform.position + new Vector3(0f, _moveDistance, 0f);
        
    }

    private void Update()
    {
        _currantTime += Time.deltaTime;
        // Используем Mathf.PingPong для создания значения между 0 и 1
        float pingPongValue = Mathf.PingPong(_currantTime,_duration) / _duration;

        // Используем Vector3.Lerp для интерполяции между начальной и конечной позициями
        Vector3 newPosition = Vector3.Lerp(_startPosition, _endPosition, pingPongValue);
        
        // Применить новую позицию к объекту
        transform.position = newPosition;
    }
}
