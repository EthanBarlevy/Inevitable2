using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Distance : MonoBehaviour
{
	TextMeshProUGUI tmp;
    Manager manager;
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        manager = FindObjectOfType<Manager>();
    }

    void Update()
    {
        tmp.SetText(Mathf.Round(manager.GetPlayerDistance() * 10) / 10 + "km");
    }
}
