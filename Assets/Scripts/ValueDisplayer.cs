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
        _text = GetComponent<TextMeshProUGUI>();
        _counter = GetComponent<Counter>();
    }

    private void OnEnable()
    {
        _counter.ValueUpdated += UpdateValueDisplay;
    }

    private void OnDisable()
    {
        _counter.ValueUpdated -= UpdateValueDisplay;
    }

    private void UpdateValueDisplay(int value)
    {
        _text.text = value.ToString();
    }

}
