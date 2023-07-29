using Colyseus.Schema;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _previusPosition;

    private void Start()
    {
        _startPosition = transform.position;
        _previusPosition = transform.position;
    }

    internal void OnChange(List<DataChange> changes)
    {

        foreach (var dataChange in changes)
        {
            switch (dataChange.Field)
            {
                case "x":
                    _startPosition.x = (float)dataChange.Value;
                    _previusPosition.x = (float)dataChange.PreviousValue;
                    break;

                case "y":
                    _startPosition.z = (float)dataChange.Value;
                    _previusPosition.z = (float)dataChange.PreviousValue;
                    break;
                default:
                    Debug.LogWarning("Не обрабатывается изменение поля: " + dataChange.Field);
                    break;
            }
        }
    }

    private void Update()
    {
        Vector3 direction = _startPosition - _previusPosition;
        transform.position = Vector3.Lerp(transform.position, _startPosition + direction, 20f * Time.deltaTime);
    }
}
