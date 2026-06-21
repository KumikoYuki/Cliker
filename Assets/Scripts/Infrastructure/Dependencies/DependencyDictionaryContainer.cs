using System;
using System.Collections.Generic;

namespace Infrastructure.StateMachine
{
    public sealed class DependencyDictionaryContainer : IDependencyContainer
    {
        private readonly Dictionary<Type, object> _storage = new();

        public void Register<TType>(TType instance)
        {
            var type =  typeof(TType);

            if (_storage.ContainsKey(type))
            {
                throw new ArgumentException($"The type {type.FullName} is already registered");
            }
            
            _storage.Add(type, instance);
        }

        public TType Resolve<TType>()
        {
            var type =  typeof(TType);

            if (_storage.TryGetValue(type, out var instance))
            {
                return (TType)instance;
            }
            
            throw new KeyNotFoundException($"No instance of type {type.FullName} is registered");
        }
    }
}