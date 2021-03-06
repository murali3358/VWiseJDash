using System;

using System.Runtime.Serialization;

namespace ICSharpCode.SharpZipLib
{
	/// <summary>
	/// SharpZipBaseException is the base exception class for the SharpZipLibrary.
	/// All library exceptions are derived from this.
	/// </summary>
	/// <remarks>NOTE: Not all exceptions thrown will be derived from this class.
	/// A variety of other exceptions are possible for example <see cref="ArgumentNullException"></see></remarks>
	[Serializable]
	public class SharpZipBaseException : ApplicationException
	{
		/// <summary>
		/// Deserialization constructor 
		/// </summary>
		/// <param name="info"><see cref="System.Runtime.Serialization.SerializationInfo"/> for this constructor</param>
		/// <param name="context"><see cref="StreamingContext"/> for this constructor</param>
		protected SharpZipBaseException(SerializationInfo info, StreamingContext context ) : base( info, context )
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the SharpZipBaseException class.
		/// </summary>
		public SharpZipBaseException()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the SharpZipBaseException class with a specified error message.
		/// </summary>
		/// <param name="message">A message describing the exception.</param>
		public SharpZipBaseException(string message) : base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the SharpZipBaseException class with a specified
		/// error message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">A message describing the exception.</param>
		/// <param name="innerException">The inner exception</param>
		public SharpZipBaseException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
