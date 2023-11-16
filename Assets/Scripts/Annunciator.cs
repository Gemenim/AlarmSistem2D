using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(IntruderLocator))]
public class Annunciator : MonoBehaviour
{
    [SerializeField] private float _rate—hange;

    private AudioSource _audioSource;
    private IntruderLocator _intruderLocator;
    private float _maxVolume = 1.0f;
    private bool _isCorutinJob = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _intruderLocator = GetComponent<IntruderLocator>();
        _audioSource.volume = 0;
    }

    private void Update()
    {
        if (_intruderLocator.IsIntruder && _isCorutinJob == false)
        {
            _isCorutinJob = true;
            StartCoroutine(ChangeVolume());
        }
    }

    private IEnumerator ChangeVolume()
    {
        while (_isCorutinJob)
        {
            if (_intruderLocator.IsIntruder)
                _audioSource.volume += _maxVolume * Time.deltaTime * _rate—hange;
            else
            {
                _audioSource.volume -= _maxVolume * _rate—hange * Time.deltaTime;

                if (_audioSource.volume == 0)
                    _isCorutinJob = false;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
