using System;
using UnityEngine;


public interface IAmplifiable
{
    public event Action<IAmplifiable> AmplifierModifierRequest;
    public bool Dirty { get; set; }
    public GemHolder AmplifierEffect { get; set; }

}