using System.Runtime.Serialization;

namespace Rpg.Providers
{
    [Serializable]
    internal class WorldProviderException : Exception
    {
        public WorldProviderException()
        {
        }

        public WorldProviderException(string message) : base(message)
        {
        }

        public WorldProviderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WorldProviderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}