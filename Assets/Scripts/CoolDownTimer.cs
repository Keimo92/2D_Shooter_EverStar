using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoolDownTimer 
{
    [SerializeField] private float coolDownTime;

    private float nextFireTime;


    public bool IsCoolingDown => Time.time < nextFireTime;

    public void StartCooldown() => nextFireTime = Time.time + coolDownTime;
}
