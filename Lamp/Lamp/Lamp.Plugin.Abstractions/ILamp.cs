using System;

namespace Lamp.Plugin.Abstractions
{
  /// <summary>
  /// Interface for Lamp
  /// </summary>
  public interface ILamp
  {
      /// <summary>
      /// Turn the lamp on
      /// </summary>
      void TurnOn();

      /// <summary>
      /// Turn the lamp off
      /// </summary>
      void TurnOff();
  }
}
