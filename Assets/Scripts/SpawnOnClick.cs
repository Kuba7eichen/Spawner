using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnOnClick : MonoBehaviour
{
    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private float _spawningDistance;
    [SerializeField] private int _maxSpawnedObjects = 10;
    private List<GameObject> _objects;
    // Update is called once per frame

    private void Start()
    {
        _objects = new List<GameObject>();
    }
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame) 
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = _spawningDistance;
            Vector3 worldpos = Camera.main.ScreenToWorldPoint(mousePos);
            if (_objects.Count < _maxSpawnedObjects)
            {
                GameObject spawned = Instantiate(_objectToSpawn, worldpos, Quaternion.identity);
                _objects.Add(spawned);
            }
            else
            {
                _objects[0].transform.position = worldpos;
                _objects.Add(_objects[0]);
                _objects.RemoveAt(0);
            }
        }
    }
}
