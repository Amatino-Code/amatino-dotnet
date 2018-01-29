//
// Amatino .NET
// Transaction.cs
//
// Author: hugh@blinkybeach.com
//
using System;

namespace Amatino
{
    public class Transaction
    {
        private int? id = null;
        private Entity entity;

        public Transaction(
            int transactionId,
            Entity entity,
            Session session,
            Action<Transaction> completion
            )
        {
            this.entity = entity;
            this.id = transactionId;
            this.retrieve(session, completion);
        }

        public Transaction(
            DateTime transactionTime,
            String description,
            GlobalUnit globalUnit,
            CustomUnit customUnit,
            int[] entries,
            Entity entity,
            Session session,
            Action<Transaction> completion
            )
        {
            var newAttributes = new NewTransactionArguments(
                transactionTime,
                description,
                globalUnit,
                customUnit,
                entries
                );

            this.create(newAttributes, session, completion);
        }

        private void create(
            NewTransactionArguments attributes,
            Session session,
            Action<Transaction> completion
            )
        {
            
        }

        private void retrieve(Session session, Action<Transaction> completion)
        {
            
        }

    }
}
