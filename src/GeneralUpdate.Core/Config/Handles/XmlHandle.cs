﻿using GeneralUpdate.Common.CustomAwaiter;
using System;

namespace GeneralUpdate.Core.Config.Handles
{
    public class XmlHandle<TEntity> : IHandle<TEntity>, IAwaiter<TEntity> where TEntity : class
    {
        public bool IsCompleted => throw new NotImplementedException();

        public TEntity GetResult()
        {
            throw new NotImplementedException();
        }

        public void OnCompleted(Action continuation)
        {
            throw new NotImplementedException();
        }

        public TEntity Read(string path)
        {
            throw new NotImplementedException();
        }

        public bool Write(string path, TEntity entities)
        {
            throw new NotImplementedException();
        }
    }
}