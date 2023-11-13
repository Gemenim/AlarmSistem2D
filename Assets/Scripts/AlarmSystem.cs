using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _rateChange;

    private float _maxVolume = 1.0f;
    private AudioSource _audioSource;
    private bool _isIntruder;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    private void Update()
    {
        if (_isIntruder)
            _audioSource.volume += _maxVolume * Time.deltaTime * _rateChange;
        else
            _audioSource.volume -= _maxVolume * _rateChange * Time.deltaTime;
    }

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
