using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ValueDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        if (TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI tmp))
        {
            _text = tmp;
        }
    }

    public void UpdateValueDisplay(int value)
    {
        _text.text = value.ToString();
    }

}
