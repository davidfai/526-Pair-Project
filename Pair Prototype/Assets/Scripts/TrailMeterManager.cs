using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrailMeterManager : MonoBehaviour
{
    public TextMeshProUGUI trailPercentText;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTrailPercentage();
    }

    public void UpdateTrailPercentage()
    {
        if (playerMovement != null)
        {
            float percentage = ((float)playerMovement.currentDecals / (float)playerMovement.maxDecals) * 100f;
            trailPercentText.SetText(percentage.ToString("F0") +"%");
        }
    }
}
