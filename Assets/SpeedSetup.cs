using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSetup : MonoBehaviour
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private CellCreator cellCreator;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float val)
    {
        text.text = (val * 1000).ToString("F0") + "ms";
        cellCreator.interval = val;
    }
}
