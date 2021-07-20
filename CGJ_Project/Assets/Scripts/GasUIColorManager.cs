using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasUIColorManager : MonoBehaviour
{
    public Slider slider;
    public Image image;

    public Color colorMax;
    public Color colorMedium;
    public Color colorLow;

    public float normalizedValue;

    public float bound1;
    public float bound2;
    public GameObject train;
    private TrainController trainController;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        image = image.GetComponent<Image>();
    }

    void Awake()
    {
        trainController = train.GetComponent<TrainController>();
    }

    // Update is called once per frame
    void Update()
    {
        normalizedValue = trainController.GetGas() / 100;
        slider.value = normalizedValue;
        if (normalizedValue >= bound1)
        {
            image.color = Color.Lerp(colorMedium, colorMax, (normalizedValue-bound1)/(1-bound1));
        }
        else
        {
            if(normalizedValue >= bound2)
            {
                image.color = Color.Lerp(colorLow, colorMedium, (normalizedValue - bound2) / (bound1 - bound2));
            }
            else
            {
                image.color = colorLow;
            }
        }
    }
}
