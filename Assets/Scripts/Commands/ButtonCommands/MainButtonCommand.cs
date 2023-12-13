using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonCommand : ICommand
{
    private int _score;

    public MainButtonCommand(int score)
    {
        _score = score;
    }

    public void Apply(EarnCoinsManager manager)
    {
        manager.AddToScoreWithoutMultiplier(_score);
    }
}
