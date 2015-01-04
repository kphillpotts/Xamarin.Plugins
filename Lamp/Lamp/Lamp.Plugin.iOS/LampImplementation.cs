using System.Diagnostics;
using Lamp.Plugin.Abstractions;
using System;
using MonoTouch.AVFoundation;
using MonoTouch.CoreMedia;
using MonoTouch.Foundation;
using MonoTouch.UIKit;


namespace Lamp.Plugin
{
    /// <summary>
    /// Implementation for Lamp
    /// </summary>
    public class LampImplementation : ILamp
    {
        // further information about access the torch for iOS can be found here
        // http://stackoverflow.com/questions/8574567/how-to-on-torch-light-without-using-camera-video-mode-in-iphone?rq=1
        // http://stackoverflow.com/questions/7852173/is-there-a-way-to-adjust-the-torch-flash-brightness-level-on-an-ios-device
        // https://github.com/xamarin/monotouch-samples/blob/master/AVCaptureFrames/Main.cs

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