using FormsIcons.iOS;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
[assembly: Xamarin.Forms.Dependency(typeof(DeviceInfoService))]  
namespace FormsIcons.iOS
{
    public class DeviceInfoService : IDeviceInfoService
    {
        public string obtenerPackageName()
        {
             return NSBundle.MainBundle.BundleIdentifier; 
        }
    }
}