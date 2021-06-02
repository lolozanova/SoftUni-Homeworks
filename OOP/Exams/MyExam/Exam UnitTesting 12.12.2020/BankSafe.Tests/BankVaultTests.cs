using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddShoudThrowExceptionByInvalidCell()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pesho", "123364488");
           Assert.Throws<ArgumentException>(()=> bankVault.AddItem("D5", item ));
        }

        [Test]
        public void AddShoudThrowExceptionWhenCellIsTaken()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pesho", "123364488");
             bankVault.AddItem("A1", item);

            Item item1 = new Item("Gosho", "123364488");
            Assert.Throws<ArgumentException>(()=> bankVault.AddItem("A1", item1));
        }
        [Test]
        public void AddShoudThrowExceptionWhenItemIsAlreadyInCell()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pesho", "123364488");
            bankVault.AddItem("A1", item);
            
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("B1", item));
        }
        [Test]
        public void AddShoudAddCorrectly()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pesho", "123364488");
            bankVault.AddItem("A1", item);

            Assert.AreEqual(bankVault.VaultCells["A1"], item);
        }
        [Test]
        public void RemoveShoudThrowExceptionWhenCellDoesntExist()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pesho", "123364488");
            bankVault.AddItem("A1", item);

            
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("D1", item));
        }
        [Test]
        public void RemoveShoudThrowExceptionWhenItemDoesntExistInThisCell()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pesho", "123364488");
            bankVault.AddItem("A1", item);
            Item item1 = new Item("Gosho","2175479421");

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", item1));
        }
        [Test]
        public void RemoveShouldSetValueOnNull()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pesho", "123364488");
            bankVault.AddItem("A1", item);
            bankVault.RemoveItem("A1", item);

            Assert.AreEqual(bankVault.VaultCells["A1"], null);
            
        }

    }
}