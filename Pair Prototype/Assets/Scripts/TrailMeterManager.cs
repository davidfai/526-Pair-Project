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
        if (playerMovement == null) { return; }
        if (!playerMovement.endGoalFlagOne)
        {
            int distanceLeft = playerMovement.maxDecals - playerMovement.currentDecals;
            trailPercentText.SetText(distanceLeft.ToString("F0") +"m");
        }
        else
        {
            int trailToRemove = playerMovement.currentDecals;
            trailPercentText.SetText(trailToRemove.ToString("F0") + "m");
        }
    }
}
