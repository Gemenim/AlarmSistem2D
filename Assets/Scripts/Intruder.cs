using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intruder : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }
}