using System.Runtime.Serialization;

namespace ParkingLotApi.Services
{
    [Serializable]
    internal class InvalidCapacityExcpetion : Exception
    {
        public InvalidCapacityExcpetion()
        {
        }

        public InvalidCapacityExcpetion(string? message) : base(message)
        {
        }

        public InvalidCapacityExcpetion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidCapacityExcpetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}