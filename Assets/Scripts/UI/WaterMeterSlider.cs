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
    public FloodDeck floodDeck;

    public int WaterLevelCount
    {
        get { return (int)_slider.value; }
    }

    public void Start()
    {
        _slider.onValueChanged.AddListener((V) =>
        {
            _sliderText.text = V.ToString("0");
            if (V >= 10)
            {
                gameCanvas.gameObject.SetActive(false);
                winOrLoseCanvas.gameObject.SetActive(true);
                loseText.gameObject.SetActive(true);
            }
            // Update the flood deck with the new water level count
            floodDeck.UpdateWaterLevelCount((int)_slider.value);
        });

    }
    public void MoveWaterLevelMarker()
    {
        _slider.value += 1;

        // Update the UI text
        _sliderText.text = _slider.value.ToString("0");

        if (_slider.value >= 10)
        {
            gameCanvas.gameObject.SetActive(false);
            winOrLoseCanvas.gameObject.SetActive(true);
            loseText.gameObject.SetActive(true);
        }

        // Update the flood deck with the new water level count
        floodDeck.UpdateWaterLevelCount((int)_slider.value);
    }



}
