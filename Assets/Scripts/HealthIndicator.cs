using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthIndicator : MonoBehaviour
{
    public TextMeshProUGUI textField;
    Health health;
    float displayedHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        displayedHealth = health.current - 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float value = health.current;
        if (Mathf.Abs(displayedHealth - value) >= 0.00001f) {
            displayedHealth = value;
            textField.text = $"{value}";
        }
    }
}
