using System.IO;
using System.Xml.Serialization;
using HB_Nieuwsbrief.Logic;
using System;

namespace HB_Nieuwsbrief.Data
{
    public class ConfigurationSource
    {
        public static void EraseOld()
        {
            string path = GetFileLocation();
            if (File.Exists(path)) File.Delete(path);
        }

        private static string GetFileLocation()
        {
            string appDataFolder = Environment.GetEnvironmentVariable("APPDATA");
            string myAppFolder = "HB_Nieuwsbrief";
            string file = "configuration.hb";

            string applicationDir = appDataFolder + "\\" + myAppFolder;

            if (!Directory.Exists(applicationDir)) Directory.CreateDirectory(applicationDir);

            return applicationDir + "\\" + file;
        }

        public static bool DoesPathExist(string path)
        {
            if (!File.Exists(path)) return false;
            return true;
        }

        public static void Write(Configuration configuration)
        {
            string path = GetFileLocation();
            using (FileStream stream = File.Open(path, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                serializer.Serialize(stream, configuration);
            }
        }
        public static Configuration Load()
        {
            string path = GetFileLocation();
            using (FileStream stream = File.Open(path, FileMode.OpenOrCreate))
            {
                XmlSerializer deSerializer = new XmlSerializer(typeof(Configuration));
                return (Configuration)deSerializer.Deserialize(stream);
            }
        }
    }
}