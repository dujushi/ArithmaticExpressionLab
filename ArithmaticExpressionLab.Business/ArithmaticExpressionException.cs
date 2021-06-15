using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ArithmaticExpressionLab.Business
{
    /// <summary>
    /// Represents exceptions related to arithmatic expression.
    /// </summary>
    [Serializable]
    public class ArithmaticExpressionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArithmaticExpressionException"/> class.
        /// </summary>
        public ArithmaticExpressionException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArithmaticExpressionException"/> class.
        /// </summary>
        /// <param name="message">The exception message</param>
        public ArithmaticExpressionException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArithmaticExpressionException"/> class.
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="inner">The inner exception</param>
        public ArithmaticExpressionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArithmaticExpressionException"/> class.
        /// </summary>
        /// <param name="info">The serialization info</param>
        /// <param name="context">The context</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected ArithmaticExpressionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
