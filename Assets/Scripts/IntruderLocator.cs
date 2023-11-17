using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Annunciator))]
public class IntruderLocator : MonoBehaviour
{
    private bool _isIntruder;
    private Annunciator _annunciator;

    public bool IsIntruder => _isIntruder;

    private void Start()
    {
        _annunciator = GetComponent<Annunciator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Intruder>(out Intruder intruder))
        {
            _isIntruder = true;
            _annunciator.StartChangeVolume();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Intruder>(out Intruder intruder))
            _isIntruder = false;
    }
}
