using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /* La classe doit instancier des gameObjects dans une zone donnée sur la
 durée
    contrairement au script précédent, pas besoin de clic
  à la place définir une vitesse d’apparition d’objets: nb d’objet/secondes
 (modifiable dans l’inspecteur)
    Les objets apparaissent au hasard dans une zone sphérique, avec un rayon à
 définir via l’inspecteur
    Les objets apparaissent avec une couleur aléatoire
    Définissez un nombre max d’objet(modifiable dans l’inspecteur)
    Pareil, si le Spawner fait apparaître plus d’objet que la limite, on
 réutilise l’objet le plus ancien à la place*/
    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private float _spawningRadius;
    [SerializeField] private float _spawningSpeed;
    [SerializeField] private float _minObjectSpeed, _maxObjectSpeed, _minRotationSpeed, _maxRotationSpeed;
    [SerializeField] private int _maxSpawnedObjects = 10;
    private List<GameObject> _objects;
    private float _counter;

    // Start is called before the first frame update
    void Start()
    {
        _objects = new List<GameObject>();
        _counter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        _counter += Time.deltaTime;
        if(_spawningSpeed != 0)
        {
            if(_counter > 1 / _spawningSpeed)
            {
                Spawn();
                _counter = 0f;
            }
        }
    }

    private void Spawn()
    {
        Vector3 spawnPoint = transform.position + Random.insideUnitSphere * _spawningRadius;
        if (_objects.Count < _maxSpawnedObjects)
        {
            GameObject obj = Instantiate(_objectToSpawn, spawnPoint, Quaternion.identity);
            obj.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            SpawnedObjectBehaviour.CreateComponent(obj, _minObjectSpeed, _maxObjectSpeed, _minRotationSpeed, _maxRotationSpeed);
            _objects.Add(obj);
            
        }
        else
        {
            _objects[0].transform.position = spawnPoint;
            _objects[0].GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            _objects.Add(_objects[0]);
            _objects.RemoveAt(0);
        }
    }
}
