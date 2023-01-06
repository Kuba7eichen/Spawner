using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObjectBehaviour : MonoBehaviour
{
    public static SpawnedObjectBehaviour CreateComponent(GameObject where, float minSpeed, float maxSpeed)
    {
        SpawnedObjectBehaviour spawnedObjectBehaviour = where.AddComponent<SpawnedObjectBehaviour>();
        spawnedObjectBehaviour._minSpeed = minSpeed;
        spawnedObjectBehaviour._maxSpeed = maxSpeed;
        return spawnedObjectBehaviour;
    }

    private float _minSpeed;
    private float _maxSpeed;
    private float _objectSpeed;
    private Vector3 _direction;
    // Start is called before the first frame update
    void Start()
    {
        _objectSpeed = Random.Range(_minSpeed, _maxSpeed);
        _direction = Random.onUnitSphere;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _direction * _objectSpeed * Time.deltaTime;
    }
}
