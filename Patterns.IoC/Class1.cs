using System;
using System.Collections.Generic;

namespace Patterns.IoC
{
    public class Program
    {
        static void Main()
        {
            // register service (iron)
            ServiceCollection.Add<IClub>(() => new IronClub());
        }

        void Toto()
        {
            // get service
            var club = ServiceCollection.GetService<IClub>();
            // use service
            club.Play();
        }
    }


    public interface IClub { void Play(); }
    // implementations
    public class IronClub : IClub { public void Play() { } }
    public class WoodClub : IClub { public void Play() { } }
    public class WedgeClub : IClub { public void Play() { } }
    public class PutterClub : IClub { public void Play() { } }

    public static class ServiceCollection
    {
        // store services in a dictionary
        private static readonly Dictionary<Type, Lazy<object>> _services
            = new Dictionary<Type, Lazy<object>>();

        // register a service, add to the dictionary
        public static void Add<T>(Func<T> func) => _services[typeof(T)] = new Lazy<object>(() => func());

        // try to get a service, from dictionary
        public static T GetService<T>()
        {
            if (_services.TryGetValue(typeof(T), out var service))
            {
                return (T)service.Value;
            }
            throw new Exception("Service not registered");
        }
    }
}
