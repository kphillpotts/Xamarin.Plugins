using System.Diagnostics;
using System.Linq;
using Windows.Phone.Media.Capture;
using Lamp.Plugin.Abstractions;
using System;

namespace Lamp.Plugin
{
  /// <summary>
  /// Implementation for Lamp
  /// </summary>
  public class LampImplementation : ILamp
  {
      private AudioVideoCaptureDevice _avDevice;      
      
      /// <summary>
      /// Turn the lamp on
      /// </summary>
      public async void TurnOn()
      {
        // further information about accessing the camera light can be found here:
        // http://developer.nokia.com/community/wiki/Using_the_camera_light_in_Windows_Phone_7,_8_and_8.1

        if (_avDevice == null)
        {
            _avDevice = await AudioVideoCaptureDevice.OpenAsync(CameraSensorLocation.Back,
                AudioVideoCaptureDevice.GetAvailableCaptureResolutions(CameraSensorLocation.Back).First());
        }

        // turn flashlight on
        var supportedCameraModes = AudioVideoCaptureDevice
            .GetSupportedPropertyValues(CameraSensorLocation.Back, KnownCameraAudioVideoProperties.VideoTorchMode);

        if (supportedCameraModes.ToList().Contains((UInt32)VideoTorchMode.On))
        {
            _avDevice.SetProperty(KnownCameraAudioVideoProperties.VideoTorchMode, VideoTorchMode.On);

            // set flash power to maxinum
            _avDevice.SetProperty(KnownCameraAudioVideoProperties.VideoTorchPower,
                AudioVideoCaptureDevice.GetSupportedPropertyRange(CameraSensorLocation.Back, KnownCameraAudioVideoProperties.VideoTorchPower).Max);
        }
        else 
            Debug.WriteLine("Torch Mode not supported by this device");
      }

      /// <summary>
      /// Turn the lamp off
      /// </summary>
      public async void TurnOff()
      {
        if (_avDevice == null)
        {
            _avDevice = await AudioVideoCaptureDevice.OpenAsync(CameraSensorLocation.Back,
                AudioVideoCaptureDevice.GetAvailableCaptureResolutions(CameraSensorLocation.Back).First());
        }

        // turn flashlight on
        var supportedCameraModes = AudioVideoCaptureDevice
            .GetSupportedPropertyValues(CameraSensorLocation.Back, KnownCameraAudioVideoProperties.VideoTorchMode);

        if (supportedCameraModes.ToList().Contains((UInt32)VideoTorchMode.On))
        {
            _avDevice.SetProperty(KnownCameraAudioVideoProperties.VideoTorchMode, VideoTorchMode.Off);

            // set flash power to maxinum
            _avDevice.SetProperty(KnownCameraAudioVideoProperties.VideoTorchPower,
                AudioVideoCaptureDevice.GetSupportedPropertyRange(CameraSensorLocation.Back, KnownCameraAudioVideoProperties.VideoTorchPower).Max);
        }
        else 
            Debug.WriteLine("Torch Mode not supported by this device");

      }
  }
}