using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private RectTransform bar;
    private Image barImage;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<RectTransform>();
        barImage = GetComponent<Image>();
        SetSize(Health.totalHealth);
    }
    public void Damage(float damage)
    {
        if ((Health.totalHealth -= damage) >= 0f)
        {  
            Health.totalHealth -= damage;
        }
        else 
        {
            Health.totalHealth = 0f;
        }
        SetSize(Health.totalHealth);
    }
        public void SetSize(float size)
        
        {
            bar.localScale = new Vector3(size, 1f);
        }
    
}
