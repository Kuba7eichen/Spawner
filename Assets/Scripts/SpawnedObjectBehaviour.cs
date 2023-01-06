using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObjectBehaviour : MonoBehaviour
{
    public static SpawnedObjectBehaviour CreateComponent(GameObject where, float minSpeed, float maxSpeed, float minRotationSpeed, float maxRotationSpeed)
    {
        SpawnedObjectBehaviour spawnedObjectBehaviour = where.AddComponent<SpawnedObjectBehaviour>();
        spawnedObjectBehaviour._minSpeed = minSpeed;
        spawnedObjectBehaviour._maxSpeed = maxSpeed;
        spawnedObjectBehaviour._minRotationSpeed = minRotationSpeed;
        spawnedObjectBehaviour._maxRotationSpeed = maxRotationSpeed;
        return spawnedObjectBehaviour;
    }

    private float _minSpeed;
    private float _maxSpeed;
    private float _minRotationSpeed;
    private float _maxRotationSpeed;
    private Vector3 _rotationAxis;
    private float _objectSpeed;
    private Vector3 _direction;
    private float _rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _objectSpeed = Random.Range(_minSpeed, _maxSpeed);
        _rotationSpeed = Random.Range(_minRotationSpeed, _maxRotationSpeed);
        _direction = Random.onUnitSphere;
        _rotationAxis = Random.onUnitSphere;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _direction * _objectSpeed * Time.deltaTime;
        transform.eulerAngles += _rotationAxis * _rotationSpeed * Time.deltaTime;
    }
}
