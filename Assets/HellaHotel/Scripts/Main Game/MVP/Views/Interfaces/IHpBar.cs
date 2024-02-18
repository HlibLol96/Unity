using System;

public interface IHpBar
{
 event Action ChangeBusEvent;
 event Action<float, float> SmallerStuff;
 void Initialize(float hp, float hunger, float thirst);
}