using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Rokxz : MonoBehaviour
{
	TextMeshProUGUI tmp;
    Manager manager;
    public bool total = false;
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        manager = FindObjectOfType<Manager>();
    }

    void Update()
    {
        if (!total)
        {
            tmp.SetText(manager.getCurrentRokxz() + "");
        }
        else
        {
			tmp.SetText(manager.GetData().rokxz + "");
		}
    }
}
