using System.Collections.Generic;
using Android.Content.PM;
using Android.Hardware;
using Android.OS;
using Lamp.Plugin.Abstractions;
using System;
using Debug = System.Diagnostics.Debug;


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
          // Additional information about using the camera light here:
          // http://forums.xamarin.com/discussion/24237/camera-led-or-flash
          // http://stackoverflow.com/questions/5503480/use-camera-flashlight-in-android?rq=1

          var camera = Camera.Open();
          if (camera == null)
          {
              Debug.WriteLine("Camera failed to initialize");
              return;
          }

          var p = camera.GetParameters();
          var supportedFlashModes = p.SupportedFlashModes;

          if (supportedFlashModes == null)
              supportedFlashModes = new List<string>();

          var flashMode = string.Empty;

          if (supportedFlashModes.Contains(Android.Hardware.Camera.Parameters.FlashModeTorch))
                  flashMode = Android.Hardware.Camera.Parameters.FlashModeTorch;

          if (!string.IsNullOrEmpty(flashMode))
          {
              p.FlashMode = flashMode;
              camera.SetParameters(p);
          }
      }


      /// <summary>
      /// Turn the lamp off
      /// </summary>
      public void TurnOff()
      {
          var camera = Camera.Open();
          if (camera == null)
          {
              Debug.WriteLine("Camera failed to initialize");
              return;
          }

          var p = camera.GetParameters();
          var supportedFlashModes = p.SupportedFlashModes;

          if (supportedFlashModes == null)
              supportedFlashModes = new List<string>();

          var flashMode = string.Empty;

          //if (on)
          //{
          if (supportedFlashModes.Contains(Android.Hardware.Camera.Parameters.FlashModeTorch))
              flashMode = Android.Hardware.Camera.Parameters.FlashModeOff;

          if (!string.IsNullOrEmpty(flashMode))
          {
              p.FlashMode = flashMode;
              camera.SetParameters(p);
          }
      }
  }
}