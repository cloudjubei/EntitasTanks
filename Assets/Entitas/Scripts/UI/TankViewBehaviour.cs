using UnityEngine;
using UnityEngine.UI;

public class TankViewBehaviour : MonoBehaviour
{
    public Transform FireTransform;
    public Slider FireAimSlider;
    
    public Slider HealthSlider;
    public Image HealthImage;
    public Color HealthFullColour = Color.green, HealthZeroColour = Color.red;

    public void ChangeColour(Color colour)
    {
        foreach(MeshRenderer r in GetComponentsInChildren<MeshRenderer>())
        {
            r.material.color = colour;
        }
    }

    public void UpdateAim(float amount)
    {
        FireAimSlider.value = amount;
    }

    public void UpdateHealth(float health)
    {
        HealthSlider.value = health;
        HealthImage.color = Color.Lerp(HealthZeroColour, HealthFullColour, health);
    }

    public void ShowDeath()
    {
        gameObject.SetActive(false);
    }

	public void ShowStart()
	{
		gameObject.SetActive(true);
	}
}