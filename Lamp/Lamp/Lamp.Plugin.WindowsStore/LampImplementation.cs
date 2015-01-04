using System.Diagnostics;
using Lamp.Plugin.Abstractions;
using System;


namespace Lamp.Plugin
{
  /// <summary>
  /// Implementation for Lamp
  /// </summary>
  public class LampImplementation : ILamp
  {
      /// <summary>
      /// Turn the lamp on
      /// </summary>
      public void TurnOn()
      {
          Debug.WriteLine("Lamp not supported on Windows Store apps.");
      }

      /// <summary>
      /// Turn the lamp off
      /// </summary>
      public void TurnOff()
      {
          Debug.WriteLine("Lamp not supported on Windows Store apps.");
      }
  }
}