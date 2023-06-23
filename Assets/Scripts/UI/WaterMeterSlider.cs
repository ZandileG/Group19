using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaterMeterSlider : MonoBehaviour
{
    public Slider _slider;
    public TextMeshProUGUI _sliderText;
    public Canvas gameCanvas;
    public Canvas winOrLoseCanvas;
    public GameObject loseText;

    public int WaterLevelCount
    {
        get { return (int)_slider.value; }
    }

    void Start()
    {
        _slider.onValueChanged.AddListener((v) =>
        {
            _sliderText.text = v.ToString("0");

            if (v >= 10)
            {
                gameCanvas.gameObject.SetActive(false);
                winOrLoseCanvas.gameObject.SetActive(true);
                loseText.gameObject.SetActive(true);
            }
           
        });
    }
}
