using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FormsIcons.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceInfoService))]
namespace FormsIcons.Droid
{
    public class DeviceInfoService : IDeviceInfoService
    {
        public string obtenerPackageName()
        {
            return Application.Context.PackageName;
        }
    }
}