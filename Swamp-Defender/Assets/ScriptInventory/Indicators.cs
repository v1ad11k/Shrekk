using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Indicators : MonoBehaviour
{
    public GameObject deathScreen;
    public Image healthBar, foodBar, waterBar;
    private Camera mainCamera;

    public float healthAmount = 100;
    private float uiHealthAmount = 100;

    public float foodAmount = 100;
    private float uiFoodAmount = 100;

   

    public float secondsToEmptyFood = 10f;

    public float secondsToEmptyHealth = 10f;

    private float changeFactor = 6f;
 
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        healthBar.fillAmount = healthAmount / 100;
        foodBar.fillAmount = foodAmount / 100;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (foodAmount > 0)
        {
            foodAmount -= 100 / secondsToEmptyFood * Time.deltaTime;
            uiFoodAmount = Mathf.Lerp(uiFoodAmount, foodAmount, Time.deltaTime * changeFactor);
            foodBar.fillAmount = uiFoodAmount / 100;

        }
        else
        {
            uiFoodAmount = 0;
            foodBar.fillAmount = uiFoodAmount / 100;
        }
        

        if (foodAmount <= 0)
        {
            healthAmount -= 100 / secondsToEmptyHealth * Time.deltaTime;
        }

        if (healthAmount <= 0)
        {
            if (!deathScreen.activeSelf)
            {
                deathScreen.SetActive(true);
                Time.timeScale = 0f;

            }


        }

        uiHealthAmount = Mathf.Lerp(uiHealthAmount, healthAmount, Time.deltaTime * changeFactor);
        healthBar.fillAmount = healthAmount / 100;
    }

    public void ChangeFoodAmount(float changeValue)
    {
        if (foodAmount + changeValue > 100)
        {
            foodAmount = 100;
        }
        else
        {
            foodAmount += changeValue;
        }
    }
    
    public void ChangeHealthAmount(float changeValue)
    {
        if (healthAmount + changeValue > 100)
        {
            healthAmount = 100;
        }

     

        else
        {
            healthAmount += changeValue;
        }
    }

 

}
