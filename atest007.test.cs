using NUnit.Framework;
using System;
using System.IO;

[TestFixture]
public class TicketPrintFormTest
{
    private string pathToTicketFile = "C:\Users\nbuga\git_ok\Case1\Receipts\Receipt_007.txt; // путь к файлу с данными билета"

    [Test]
    public void TestTicketPrintForm()
    {
        string[] lines = File.ReadAllLines(pathToTicketFile);

        string date = lines[3].Split(' ')[1];
        string departureStation = lines[5].Substring(3);
        string destinationStation = lines[6].Substring(3);
        string ticketNumber = lines[8].Split(':')[1].Trim();
        string systemNumber = lines[8].Split(':')[2].Trim();

        string transport = lines[10].Substring(11);
        string price = lines[11].Split(':')[1].Trim();
        string total = lines[12].Split(':')[1].Trim();

        Assert.AreEqual("29.07.2023", date);
        Assert.AreEqual("Московский вокзал", departureStation);
        Assert.AreEqual("Пл. 75 км", destinationStation);
        Assert.AreEqual("00004", ticketNumber);
        Assert.AreEqual("0001000000004", systemNumber);
        Assert.AreEqual("Перевозка Разовый Полный -> П 80", transport);
        Assert.AreEqual("80.00", price);
        Assert.AreEqual("80,00", total);
    }
}
