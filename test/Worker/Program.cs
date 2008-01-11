using System;
using NServiceBus;
using Common.Logging;

namespace Worker
{
    class Program
    {
        static void Main()
        {
            LogManager.GetLogger("hello").Debug("Started.");
            ObjectBuilder.SpringFramework.Builder builder = new ObjectBuilder.SpringFramework.Builder();

            try
            {
                IBus bServer = builder.Build<IBus>();
                bServer.Start();

                bServer.Subscribe(typeof(Messages.Event));

                Console.Read();
            }
            catch (Exception e)
            {
                LogManager.GetLogger("hello").Fatal("Exiting", e);
                Console.Read();
            }

        }
    }
}
