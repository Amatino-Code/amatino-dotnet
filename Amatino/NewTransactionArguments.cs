//
// Amatino .NET
// NewTransactionArguments.cs
//
// Author: hugh@blinkybeach.com
//

using System;

namespace Amatino
{
    public class InvalidTransactionArguments: Exception
    {
        public InvalidTransactionArguments(String message)
            : base(message)
        {}
    }

    internal class NewTransactionArguments
    {
        private const int MaxDescriptionLength = 1024;

        private const String ErrTwoUnits = @"
        Supply at least one of either customUNit or globalUnit, but not both
        ";

        private readonly String ErrDescriptionLength = "Transaction description"
        + " is limited to" + MaxDescriptionLength.ToString() + "characters";

        private const String ErrNullArgument = @"
        TransactionTime and 
        ";

        private readonly DateTime transactionTime;
        private readonly String description;
        private readonly GlobalUnit globalUnit;
        private readonly CustomUnit customUnit;
        private readonly int[] entries;

        public NewTransactionArguments(
            DateTime transactionTime,
            String description,
            GlobalUnit globalUnit,
            CustomUnit customUnit,
            int[] entries
            )
        {

            if (globalUnit != null && customUnit != null)
            {
                throw new InvalidTransactionArguments(ErrTwoUnits);
            }

            if (globalUnit == null && customUnit == null)
            {
                throw new InvalidTransactionArguments(ErrTwoUnits);
            }

            if (entries == null || transactionTime == null)
            {
                throw new ArgumentNullException(ErrNullArgument);
            }

            if (description == null)
            {
                description = "";
            }

            if (description.Length > MaxDescriptionLength)
            {
                throw new InvalidTransactionArguments(ErrDescriptionLength);
            }

            this.transactionTime = transactionTime;
            this.description = description;
            this.globalUnit = globalUnit;
            this.customUnit = customUnit;
            this.entries = entries;

        }

    }
}
