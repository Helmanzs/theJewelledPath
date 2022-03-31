using System;
using System.Collections.Generic;
using UnityEngine;


public interface IAmplifiable
{
    public event Action<IAmplifiable> AmplifierModifierRequest;
    public GemHolder AmplifierEffect { get; set; }
    public float AmplifierNumberEffect { get; set; }
    public List<Amplifier> Amplifiers { get; set; }

}