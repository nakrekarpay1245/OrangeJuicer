using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [Header("Slider Deðiþkenleri")]
    [SerializeField]
    private float currentValue;
    [SerializeField]
    private float maxValue;

    [Space]
    [SerializeField]
    private Slider slider;

    public bool isLocalCanvas = true;

    private Transform mainCamera;
    private void Awake()
    {
        // slider = GetComponent<Slider>();
        mainCamera = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        if (isLocalCanvas)
            transform.LookAt(mainCamera);
    }

    public void SetMaxValue(float value)
    {
        maxValue = value;

        if (slider)
            slider.maxValue = maxValue;

        SetCurrentValue(maxValue);
    }

    public void SetCurrentValue(float value)
    {
        currentValue = value;

        if (slider)
            slider.value = currentValue;

        // Debug.Log(gameObject.name + " bar value: " + currentValue);
    }
}

