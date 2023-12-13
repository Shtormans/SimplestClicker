using UnityEngine;

public class MainClickButton : Clickable
{
    [SerializeField, Range(0, 20)] private const int _score = 5;

    public void Click()
    {
        var command = new MainButtonCommand(_score);

        base.Click(command);
    }
}
