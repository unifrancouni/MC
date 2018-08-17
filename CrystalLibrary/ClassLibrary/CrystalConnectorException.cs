using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
namespace CrystalLibrary
{
    [Serializable]
    public class CrystalConnectorException : Exception
    {
        public CrystalConnectorException()
        {
        }
        public CrystalConnectorException(string message)
            : base(message)
        {
        }
        protected CrystalConnectorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        public CrystalConnectorException(string message, Exception inner)
            : base(message, inner)
        {
        }
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
