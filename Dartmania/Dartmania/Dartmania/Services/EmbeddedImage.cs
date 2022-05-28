using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace Dartmania.Services
{
    [ContentProperty(nameof(Source))]
    public static class EmbeddedImage
    {
        public static string Source { get; set; }

        public static object ProvideValue (IServiceProvider serviceProvider)
        {
            if(Source == null)
            {
                return null;
            }
            var imageSource = ImageSource.FromResource(Source, typeof(EmbeddedImage).GetTypeInfo().Assembly);
            return imageSource;
        }
    }
}
