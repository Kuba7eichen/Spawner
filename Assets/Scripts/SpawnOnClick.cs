using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnOnClick : MonoBehaviour
{
    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private float _spawningDistance;
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame) // returns true when the mouse left button is pressed
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = _spawningDistance;
            Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(_objectToSpawn, Worldpos, Quaternion.identity);
        }
    }
}
