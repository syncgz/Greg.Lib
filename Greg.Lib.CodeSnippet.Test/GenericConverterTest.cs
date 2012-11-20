using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Greg.Lib.CodeSnippet.Test
{
    public class GenericConverterTest
    {
        [TestFixture]
        public class CacheTest
        {
            [Test]
            public void TryConvertObject_VTypeNoMismatch_ResultOk()
            {
                int cacheItem = 10;

                int returnItem = GenericConverter.TryConvertObject<int>(cacheItem);

                Assert.AreEqual(cacheItem, returnItem);
            }

            [Test]
            public void TryConvertObject_VTypeMismatch_ReturnZero()
            {
                TestClass cacheItem = new TestClass();

                int returnItem = GenericConverter.TryConvertObject<int>(cacheItem);

                Assert.AreEqual(returnItem, 0);
            }

            [Test]
            public void TryConvertObject_RTypeMismatch_ReturnNull()
            {
                int cacheItem = 10;

                var returnItem = GenericConverter.TryConvertObject<TestClass>(cacheItem);

                Assert.AreEqual(returnItem, null);
            }

            [Test]
            public void TryConvertObject_RTypeNoMismatch_ReturnNull()
            {
                TestClass cacheItem = new TestClass();

                var returnItem = GenericConverter.TryConvertObject<TestClass>(cacheItem);

                Assert.NotNull(returnItem);
                Assert.AreEqual(returnItem.Test, cacheItem.Test);
            }

            [Test]
            public void TryConvertObject_RTypeIsNull_ReturnNull()
            {
                TestClass cacheItem = null;

                var returnItem = GenericConverter.TryConvertObject<TestClass>(cacheItem);

                Assert.IsNull(returnItem);

            }

            [Test]
            public void ConvertObject_VTypeNoMismatch_ResultOk()
            {
                int cacheItem = 10;

                int returnItem = GenericConverter.ConvertObject<int>(cacheItem);

                Assert.AreEqual(cacheItem, returnItem);
            }

            [Test]
            public void ConvertObject_VTypeMismatch_ThrowsException()
            {
                TestClass cacheItem = new TestClass();

                Assert.Throws<InvalidCastException>(() => GenericConverter.ConvertObject<int>(cacheItem));
            }

            [Test]
            public void ConvertObject_RTypeMismatch_ReturnNull()
            {
                int cacheItem = 10;

                Assert.Throws<InvalidCastException>(() => GenericConverter.ConvertObject<TestClass>(cacheItem));
            }

            [Test]
            public void ConvertObject_RTypeNoMismatch_ReturnNull()
            {
                TestClass cacheItem = new TestClass();

                var returnItem = GenericConverter.ConvertObject<TestClass>(cacheItem);

                Assert.NotNull(returnItem);
                Assert.AreEqual(returnItem.Test, cacheItem.Test);
            }

            [Test]
            public void ConvertObject_RTypeIsNull_ReturnNull()
            {
                TestClass cacheItem = null;

                var returnItem = GenericConverter.ConvertObject<TestClass>(cacheItem);

                Assert.IsNull(returnItem);

            }

        }

        class TestClass
        {
            public int Test = 10;
        }
    }
}
