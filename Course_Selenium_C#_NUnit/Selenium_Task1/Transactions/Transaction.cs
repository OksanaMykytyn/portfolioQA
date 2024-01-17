namespace Transactions
{
    public class Transaction
    {
        public decimal FullSum(decimal TransferAmount)
        {
            decimal fee;
            decimal minTransferAmount = 10;
            decimal maxTransferAmount = 1000000;

            if (TransferAmount < minTransferAmount)
            {
                throw new AggregateException("The transaction amount is less than the minimum amount");
            }
            else if (TransferAmount > maxTransferAmount)
            {
                throw new AggregateException("The transaction amount is greater than the maximum amount");
            }
            else if (TransferAmount < 1000 && TransferAmount >= 10)
            {
                fee = 0.1M;
            }
            else if (TransferAmount < 10000 && TransferAmount >= 1000)
            {
                fee = 0.05M;
            }
            else
            {
                fee = 0.01M;
            }

            return TransferAmount + TransferAmount * fee;
        }
    }
}
