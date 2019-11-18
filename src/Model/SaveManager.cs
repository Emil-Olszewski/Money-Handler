using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Money_App.Model
{
    public static class SaveManager
    {
        public static void SaveTransactions(List<Transaction> transactions, string filePath)
        {
            string json = JsonConvert.SerializeObject(transactions);
            File.WriteAllText(filePath, json);
        }

        public static List<Transaction> LoadTransactions(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Transaction>>(json);
        }
    }
}
