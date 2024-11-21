using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private bool _isActive = false;
    private int _counterValue = 0;
    private float _delay = 0.5f;
    private Coroutine _coroutine;
    private ValueDisplayer _valueDisplayer;

    private void Start()
    {
        if (TryGetComponent<ValueDisplayer>(out ValueDisplayer valueDisplayer))
        {
            _valueDisplayer = valueDisplayer;
            _valueDisplayer.UpdateValueDisplay(_counterValue);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
            _valueDisplayer.UpdateValueDisplay(_counterValue);
            yield return wait;
        }
    }
}
