using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusButtonCommand : ICommand
{
    private float _multiplier;
    private float _seconds;

    public BonusButtonCommand(float score, float seconds)
    {
        _multiplier = score;
        _seconds = seconds;
    }

    public void Apply(EarnCoinsManager manager)
    {
        manager.AddToMultiplierWithTime(_multiplier, _seconds);
    }
}
