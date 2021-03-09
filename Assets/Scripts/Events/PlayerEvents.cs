using System.Collections;
using System.Collections.Generic;
using Systems.Health_System;
using UnityEngine;

public class PlayerEvents
{
    public delegate void PlayerHealthSet(HealthComponent healthComponent);

    public static event PlayerHealthSet OnPlayerHealthSet;

    public static void Invoke_OnPlayerHealthSet(HealthComponent healthComponent)
    {
        OnPlayerHealthSet?.Invoke(healthComponent);
    }
}
