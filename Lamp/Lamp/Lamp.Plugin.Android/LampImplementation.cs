using System.Collections.Generic;
using Android.Content.PM;
using Android.Hardware;
using Android.OS;
using Lamp.Plugin.Abstractions;
using System;
using Debug = System.Diagnostics.Debug;
using Camera = Android.Hardware.Camera;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.IO;


namespace Lamp.Plugin
{
  /// <summary>
  /// Implementation for Lamp
  /// </summary>
  public class LampImplementation : ILamp
  {
      private Camera camera;

      /// <summary>
      /// Turn the lamp on
      /// </summary>
      public void TurnOn()
      {
          // Additional information about using the camera light here:
          // http://forums.xamarin.com/discussion/24237/camera-led-or-flash
          // http://stackoverflow.com/questions/5503480/use-camera-flashlight-in-android?rq=1

          if (camera == null)
              camera = Camera.Open();

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

          camera.StartPreview();

          // nexus 5 fix here: http://stackoverflow.com/questions/21417332/nexus-5-4-4-2-flashlight-led-not-turning-on
          try
          {
              camera.SetPreviewTexture(new SurfaceTexture(0));
          }
          catch (IOException ex)
          {
              // Ignore
          }

      }


      /// <summary>
      /// Turn the lamp off
      /// </summary>
      public void TurnOff()
      {
          if (camera == null)
              camera = Camera.Open();

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
              flashMode = Android.Hardware.Camera.Parameters.FlashModeOff;

          if (!string.IsNullOrEmpty(flashMode))
          {
              p.FlashMode = flashMode;
              camera.SetParameters(p);
          }
          
          // sstevan: Fix "getParameters failed (empty parameters)" issue
          camera.StopPreview();
          camera.Release();
          camera = null;
          
      }
  }
}
