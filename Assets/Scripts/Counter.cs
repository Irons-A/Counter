using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action<int> ValueUpdated;

    const int MouseButtonIndex = 0;

    [SerializeField] private int _counterValue = 0;

    private bool _isActive = false;
    private float _delay = 0.5f;
    private Coroutine _coroutine;

    private void Start()
    {
        ValueUpdated?.Invoke(_counterValue);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseButtonIndex))
        {
            if (_isActive)
            {
                StopCoroutine();
            }
            else
            {
                StartCoroutine();
            }
        }
    }

    private void StartCoroutine()
    {
        _coroutine = StartCoroutine(CounterCRT(_delay));
        _isActive = true;
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _isActive = false;
        }
    }

    private IEnumerator CounterCRT(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while(true)
        {
            _counterValue++;
            ValueUpdated?.Invoke(_counterValue);
            yield return wait;
        }
    }
}
