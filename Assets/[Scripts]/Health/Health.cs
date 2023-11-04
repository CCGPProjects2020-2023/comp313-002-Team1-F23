using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Transform unit;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        transform.parent.rotation = Camera.main.transform.rotation;
        transform.position = unit.position + offset;
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        slider.value = currentHealth / maxHealth ;
    }
}
