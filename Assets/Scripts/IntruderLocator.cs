using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntruderLocator : MonoBehaviour
{
    private bool _isIntruder;

    public bool IsIntruder => _isIntruder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Intruder>(out Intruder intruder))
            _isIntruder = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Intruder>(out Intruder intruder))
            _isIntruder = false;
    }
}
