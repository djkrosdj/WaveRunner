using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScaleChangingObstacle : MonoBehaviour
{
    
    [SerializeField] private float _duration = 1f;
    [SerializeField] private float _scaleSize = 2f;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    
    // Start is called before the first frame update
    private void Start()
    {
        // Определяем начальную и конечную позиции размера от текущей позиции объекта
        var Scale = transform.localScale;
        _startPosition = Scale;
        _endPosition = Scale + new Vector3(_scaleSize, _scaleSize, 0f);
    }

    private void Update()
    {
        // Используем Mathf.PingPong для создания значения между 0 и 1
        float pingPongValue = Mathf.PingPong(Time.time * _duration, _scaleSize)/_scaleSize;
        
        // Используем Vector3.Lerp для интерполяции между начальной и конечной позициями
        Vector3 newPosition = Vector3.Lerp(_startPosition, _endPosition, pingPongValue);
        
        // Применить новую позицию к объекту
        transform.localScale = newPosition;
    }
}
