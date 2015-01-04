using System.Diagnostics;
using Windows.Media.Capture;
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
      public async void TurnOn()
      {
          var mediaDev = new MediaCapture();
          await mediaDev.InitializeAsync();
          var videoDev = mediaDev.VideoDeviceController;
          var torchControl = videoDev.TorchControl;
          if (torchControl.Supported)
          {
              if (torchControl.PowerSupported) torchControl.PowerPercent = 100;
              torchControl.Enabled = true;
          }
          else
              Debug.WriteLine("Torch Control not supported on this device");
      }

      /// <summary>
      /// Turn the lamp off
      /// </summary>
      public async void TurnOff()
      {
          var mediaDev = new MediaCapture();
          await mediaDev.InitializeAsync();
          var videoDev = mediaDev.VideoDeviceController;
          var torchControl = videoDev.TorchControl;
          if (torchControl.Supported)
              torchControl.Enabled = false;
          else
              Debug.WriteLine("Torch Control not supported on this device");
      }
  }
}