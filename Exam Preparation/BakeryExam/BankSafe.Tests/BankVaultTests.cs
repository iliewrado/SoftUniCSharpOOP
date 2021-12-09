using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        Item item = new Item("Gosho", "123");

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
        }

        [Test]
        public void CtorTest()
        {
            Assert.IsNotNull(bankVault);
        }

        [Test]
        public void AddItemTest()
        {
            bankVault.AddItem("A1", item);
            Assert.AreEqual(item, bankVault.VaultCells["A1"]);
            Assert.AreEqual("Gosho", bankVault.VaultCells["A1"].Owner);
            Assert.AreEqual("123", bankVault.VaultCells["A1"].ItemId);
        }

        [Test]
        public void AddItemThrowExceptionInvalidCell()
        {
            Assert.Throws<ArgumentException>
                (() => bankVault.AddItem("D4", item));
        }

        [Test]
        public void AddItemThrowExceptionTakenCell()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>
                (() => bankVault.AddItem("A1", item));
        }

        [Test]
        public void AddThrowExceptionExistingItem()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>
                (() => bankVault.AddItem("B2", item));
        }

        [Test]
        public void AddItemReturnStringTest()
        {
            Assert.AreEqual("Item:123 saved successfully!",
                            bankVault.AddItem("A1", item));
        }

        [Test]
        public void RemoveThrowExceptionInvalidCell()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>
                (() => bankVault.RemoveItem("D4", item));
        }

        [Test]
        public void RemoveThrowExceptionInvalidItem()
        {
            bankVault.AddItem("A1", item);
            Item invalid = new Item("Pesho", "456");
            Assert.Throws<ArgumentException>
               (() => bankVault.RemoveItem("A1", invalid));
        }

        [Test]
        public void RemoveItemTest()
        {
            bankVault.AddItem("A1", item);
            Assert.AreEqual("Remove item:123 successfully!",
                bankVault.RemoveItem("A1", item));
        }
    }
}