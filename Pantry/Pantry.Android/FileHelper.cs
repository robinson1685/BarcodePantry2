using System;
using System.IO;
using Xamarin.Forms;
using Pantry.Droid;


[assembly: Dependency(typeof(FileHelper))]
namespace Pantry.Droid
{
    public class FileHelper 
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}