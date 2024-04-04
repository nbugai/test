using NUnit.Framework;
using System.IO;

namespace MyTests
{
    [TestFixture]
    public class MyTextFileTest
    {
        [Test]
        public void TestTextFileData()
        {
            string filePath = "C:\Users\nbuga\git_ok\Case1\Receipts\Receipt_007.txt";

            // Чтение текстового файла
            string[] lines = File.ReadAllLines(filePath);

            // Объявление переменных для извлеченных данных
            string travelDate = "";
            string departureStation = "";
            string destinationStation = "";
            string ticketNumber = "";
            string systemNumber = "";
            string transportInfo = "";
            string ticketCost = "";
            string totalCost = "";

            foreach (string line in lines)
            {
                if (line.Contains("на"))
                {
                    travelDate = line.Split("на ")[1].Split(" - > ")[0].Trim();
                }
                else if (line.Contains("от "))
                {
                    departureStation = line.Substring(line.IndexOf("от ") + 3);
                }
                else if (line.Contains("до "))
                {
                    destinationStation = line.Substring(line.IndexOf("до ") + 3);
                }
                else if (line.Contains("Билет N:"))
                {
                    ticketNumber = line.Split(':')[1].Split()[0].Trim();
                    systemNumber = line.Split(':')[2].Trim();
                }
                else if (line.Contains("Перевозка"))
                {
                    transportInfo = line.Split(" -> ")[1].Trim();
                }
                else if (line.Contains("Стоимость по тарифу"))
                {
                    ticketCost = line.Split(':')[1].Trim().Replace("= ", "");
                }
                else if (line.Contains("ИТОГ"))
                {
                    totalCost = line.Split(':')[1].Trim().Replace(',', '.');
                }
            }

            // Assert для извлеченных данных
            Assert.AreEqual("29.07.2023", travelDate);
            Assert.AreEqual("Московский вокзал", departureStation);
            Assert.AreEqual("Пл. 75 км", destinationStation);
            Assert.AreEqual("00004", ticketNumber);
            Assert.AreEqual("0001000000004", systemNumber);
            Assert.AreEqual("Разовый Полный", transportInfo);
            Assert.AreEqual("80.00", ticketCost);
            Assert.AreEqual("80.00", totalCost);
        }
    }
}