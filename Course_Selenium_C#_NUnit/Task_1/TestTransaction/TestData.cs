namespace TestTransaction
{
    public class TestData
    {
        public static IEnumerable<TestCaseData> MinSumData()
        {
            yield return new TestCaseData(9.9m);
            yield return new TestCaseData(10m);
            yield return new TestCaseData(10.1m);
        }

        public static IEnumerable<TestCaseData> MaxSumData()
        {
            yield return new TestCaseData(999999.9m);
            yield return new TestCaseData(1000000m);
            yield return new TestCaseData(1000000.2m);
        }

        public static IEnumerable<TestCaseData> Per10SumData()
        {
            yield return new TestCaseData(10m, 11m);
            yield return new TestCaseData(10.5m, 11.55m);
            yield return new TestCaseData(998m, 1098.9m);
            yield return new TestCaseData(999.5m, 1099.45m);
            yield return new TestCaseData(20000m, 22000m);
        }

        public static IEnumerable<TestCaseData> Per5SumData()
        {
            yield return new TestCaseData(999m, 1098.9m);
            yield return new TestCaseData(999.9m, 1049.895m);
            yield return new TestCaseData(1000.1m, 1050.105m);
            yield return new TestCaseData(10000m, 10500m);
            yield return new TestCaseData(10000.5m, 10500.525m);
        }

        public static IEnumerable<TestCaseData> Per1SumData()
        {
            yield return new TestCaseData(10000.5m, 10100.505m);
            yield return new TestCaseData(200000m, 202000m);
            yield return new TestCaseData(9999m, 10098.99m);
            yield return new TestCaseData(89m, 89.89m);
            yield return new TestCaseData(300m, 300m);
        }
    }
}
