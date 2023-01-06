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
        if (Mouse.current.leftButton.wasPressedThisFrame) // returns true when the mouse left button is pressed
        {
            if (_objects.Count < _maxSpawnedObjects)
            {
                Vector3 mousePos = Mouse.current.position.ReadValue();
                mousePos.z = _spawningDistance;
                Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
                GameObject spawned = Instantiate(_objectToSpawn, Worldpos, Quaternion.identity);
                _objects.Add(spawned);
            }
        }
    }
}
