﻿using System;

namespace d60.EventSorcerer.Aggregates
{
    /// <summary>
    /// Repository of aggregate roots.
    /// </summary>
    public interface IAggregateRootRepository
    {
        /// <summary>
        /// Returns a fully hydrated and ready to use aggregate root instance of the specified type. Optionally, if <seealso cref="maxGlobalSequenceNumber"/> is set,
        /// only events up until (and including) the specified sequence number are applied.
        /// </summary>
        Root<TAggregate> Get<TAggregate>(Guid aggregateRootId, long maxGlobalSequenceNumber = long.MaxValue) where TAggregate : AggregateRoot, new();

        /// <summary>
        /// Checks whether an aggregate root of the specified type with the specified ID exists. Optionally, if <seealso cref="maxGlobalSequenceNumber"/> is set,
        /// it is checked whether the root exists at the given point in time (including the specified sequence number)
        /// </summary>
        bool Exists<TAggregate>(Guid aggregateRootId, long maxGlobalSequenceNumber = long.MaxValue) where TAggregate : AggregateRoot;
    }

    public class Root<TAggregate> where TAggregate : AggregateRoot
    {
        public Root(TAggregate aggregateRoot, long lastSeqNo, long lastGlobalSeqNo)
        {
            AggregateRoot = aggregateRoot;
            LastSeqNo = lastSeqNo;
            LastGlobalSeqNo = lastGlobalSeqNo;
        }

        public TAggregate AggregateRoot { get; private set; }
        public long LastSeqNo { get; private set; }
        public long LastGlobalSeqNo { get; private set; }
    }
}