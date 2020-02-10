using MailSenderLib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Tests.Services.InMemory
{
    [TestClass]
    public class RecipientsStoreInMemoryTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Create_throw_ArgumentNullException_if_items_is_null()
        {
            var store = new RecipientsStoreInMemory();

            store.Create(null);
        }

        [TestMethod]
        public void Create_throw_ArgumentNullException_if_items_is_null2()
        {
            var store = new RecipientsStoreInMemory();

            Assert.ThrowsException<ArgumentNullException>(() => store.Create(null));
        }
    }
}
