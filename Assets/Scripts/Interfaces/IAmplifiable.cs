using System;
using System.Collections.Generic;
using UnityEngine;


public interface IAmplifiable
{
    public event Action<IAmplifiable> AmplifierModifierRequest;
    public GemHolder AmplifierEffect { get; }
    public List<Amplifier> Amplifiers { get; set; }
    public void RequestAmplifierModifiers();
}