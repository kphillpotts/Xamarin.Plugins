## Lamp

Simple way of controlling the lamp on the back of your phone from Xamarin and Xamarin.Forms projects

#### Setup
* Available on NuGet: https://www.nuget.org/packages/kphillpotts.Lamp.Plugin/
* Install into your PCL project and Client projects.

**Supports**
* Xamarin.iOS
* Xamarin.iOS (x64 Unified)
* Xamarin.Android
* Windows Phone 8 (Silverlight)
* Windows Phone 8.1 RT

**WINDOWS PHONE Specitic**
Necessary capabilities: ID_CAP_ISV_CAMERA, ID_CAP_MICROPHONE

**ANDROID Specific**
Please ensure you have the following permissions enabled:

```
<uses-permission android:name="android.permission.CAMERA" />
<uses-permission android:name="android.permission.FLASHLIGHT"/>
<uses-feature android:name="android.hardware.camera" />
<uses-feature android:name="android.hardware.camera.autofocus" />
<uses-feature android:name="android.hardware.camera.flash" />
```

#### API Usage

To gain access to the Lamp class simply use this method:

```
var v = CrossLamp.Current;
```

#### Methods

```
 CrossLamp.Current.TurnOn();
```
Turns on the lamp

```
 CrossLamp.Current.TurnOff();
```
Turns off the lamp

#### Contributors
* [kphillpotts](https://github.com/kphillpotts)

#### License
Licensed under main repo license
