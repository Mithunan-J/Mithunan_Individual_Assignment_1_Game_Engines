using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public float health = 100f;
    public GameObject playerHealthText;
    // Start is called before the first frame update
    void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        playerHealthText.GetComponent<TextMeshProUGUI>().text = "Player Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth(float healthValue)
    {
        health += healthValue;
        Debug.Log("Player Health: " + health);
        playerHealthText.GetComponent<TextMeshProUGUI>().text = "Player Health: " + health;
    }
}
