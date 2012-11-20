using NUnit.Framework;

namespace Greg.Lib.Cache.MemoryCache.Test.Integration
{
    [TestFixture]
    public class CacheTest
    {
        [SetUp]
        public void Initialization()
        {
            Cache.Clear();
        }
        
        [Test]
        public void WriteAndReadValueType()
        {
            int testItem = 10;
            
            string cacheItemName = "cacheItemName";

            Cache.Set(testItem,cacheItemName);

            int cacheItem = Cache.Get<int>(cacheItemName);

            Assert.AreEqual(testItem,cacheItem);
        }

        [Test]
        public void WriteAndReadReferenceType()
        {
            var testItem = new TestClass() {TestProp = 10};

            string cacheItemName = "cacheItemName";

            Cache.Set(testItem, cacheItemName);

            var cacheItem = Cache.Get<TestClass>(cacheItemName);


            Assert.IsNotNull(cacheItem);
            Assert.AreEqual(testItem.TestProp, cacheItem.TestProp);
        }

        [Test]
        public void Initilize_OneDelegateReferenceType_ResultOk()
        {
            var item = new TestClassInitializer();

            Cache.Initialize(item);

            var cacheItem = Cache.Get<TestClass>(item.GetName());

            Assert.IsNotNull(cacheItem);
            Assert.AreEqual(item.GetObject().TestProp,cacheItem.TestProp);
        }

        [Test]
        public void Initilize_OneDelegateValueType_ResultOk()
        {
            var item = new ValueInitializer();

            Cache.Initialize(item);

            var cacheItem = Cache.Get<int>(item.GetName());

            Assert.IsNotNull(cacheItem);
            Assert.AreEqual(item.GetObject(), cacheItem);
        }
    }

    public class TestClass
    {
        public int TestProp { get; set; }
    }

    public class TestClassInitializer : ICacheInitializer<TestClass>
    {
        public TestClass GetObject()
        {
            return new TestClass(){TestProp = 100};
        }

        public string GetName()
        {
            return "Name";
        }
    }

    public class ValueInitializer : ICacheInitializer<int>
    {
        public int GetObject()
        {
            return 1000;
        }

        public string GetName()
        {
            return "Name1";
        }
    }
}
