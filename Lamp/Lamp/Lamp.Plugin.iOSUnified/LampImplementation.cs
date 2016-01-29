using System.Diagnostics;
using AVFoundation;
using Foundation;
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
          var captureDevice = AVCaptureDevice.DefaultDeviceWithMediaType(AVMediaType.Video);
          if (captureDevice == null)
          {
              Debug.WriteLine("No captureDevice - this won't work on the simulator, try a physical device");
              return;
          }

          NSError error = null;
          captureDevice.LockForConfiguration(out error);
          if (error != null)
          {
              Debug.WriteLine(error);
              captureDevice.UnlockForConfiguration();
              return;
          }
          else
          {
			  if (!captureDevice.TorchAvailable)
			  {
				  Debug.WriteLine("The torch is not available on this device (captureDevice.TorchAvailable is false)");
				  return;
			  }
              if (captureDevice.TorchMode != AVCaptureTorchMode.On)
              {
                  captureDevice.TorchMode = AVCaptureTorchMode.On;
              }
              captureDevice.UnlockForConfiguration();
          }
      }



      /// <summary>
      /// Turn the lamp off
      /// </summary>
      public void TurnOff()
      {
          var captureDevice = AVCaptureDevice.DefaultDeviceWithMediaType(AVMediaType.Video);
          if (captureDevice == null)
          {
              Debug.WriteLine("No captureDevice - this won't work on the simulator, try a physical device");
              return;
          }

          NSError error = null;
          captureDevice.LockForConfiguration(out error);
          if (error != null)
          {
              Debug.WriteLine(error);
              captureDevice.UnlockForConfiguration();
              return;
          }
          else
          {
              if (captureDevice.TorchMode != AVCaptureTorchMode.Off)
              {
                  captureDevice.TorchMode = AVCaptureTorchMode.Off;
              }
              captureDevice.UnlockForConfiguration();
          }
      }
  }
}