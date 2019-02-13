using Newtonsoft.Json;
using System.IO;

namespace SA.Common.Helpers
{
    public static class FileHelper
    {
        public static void SerializeInput(string path, object list)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(Path.GetDirectoryName(path));

            File.WriteAllText(path, JsonConvert.SerializeObject(list, Formatting.Indented));
        }

        public static T DeserializeOutput<T>(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            Jsonify(path);
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }

        private static void Jsonify(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);

            File.WriteAllText(filePath, $"[{fileContent}]");
        }
    }
}