using System;
using UnityEngine;

public abstract class Clickable : MonoBehaviour
{
    public event Action<ICommand> OnClick;

    public virtual void Click(ICommand command = null)
    {
        OnClick.Invoke(command);
    }
}
