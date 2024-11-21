using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private bool _isActive = false;
    private int _counterValue = 0;
    private float _delay = 0.5f;
    private Coroutine _coroutine;

    private void Start()
    {
        if(TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI component))
        {
            _text = component;
            _text.text = _counterValue.ToString();
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
            _text.text = _counterValue.ToString();
            yield return wait;
        }
    }
}
