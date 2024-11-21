using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ValueDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void Awake()
    {
        if (TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI tmp))
        {
            _text = tmp;
        }

        if (TryGetComponent<Counter>(out Counter counter))
        {
            _counter = counter;
        }
    }

    private void OnEnable()
    {
        _counter.ValueUpdated += UpdateValueDisplay;
    }

    private void OnDisable()
    {
        _counter.ValueUpdated -= UpdateValueDisplay;
    }

    public void UpdateValueDisplay(int value)
    {
        _text.text = value.ToString();
    }

}
