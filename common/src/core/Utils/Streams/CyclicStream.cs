﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VVVV.Utils.Streams
{
    public class CyclicStream<T> : IInStream<T>
    {
        private readonly IInStream<T> FSource;

        public CyclicStream(IInStream<T> source)
        {
            FSource = source;
        }

        public CyclicStreamReader<T> GetReader()
        {
            return new CyclicStreamReader<T>(FSource);
        }

        IStreamReader<T> IInStream<T>.GetReader()
        {
            return GetReader();
        }

        public int Length
        {
            get { return FSource.Length; }
        }

        public object Clone()
        {
            return new CyclicStream<T>(FSource);
        }

        public bool Sync()
        {
            return FSource.Sync();
        }

        public bool IsChanged
        {
            get { return FSource.IsChanged; }
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return GetReader();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
