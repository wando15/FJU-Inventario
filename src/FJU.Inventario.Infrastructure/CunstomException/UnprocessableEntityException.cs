using System.Globalization;

namespace FJU.Inventario.Infrastructure.CunstomException
{
    [Serializable]
    public class UnprocessableEntityException : Exception
    {
        public UnprocessableEntityException() { }

        public UnprocessableEntityException(string message)
            : base(message) { }

        public UnprocessableEntityException(string message, Exception inner)
            : base(message, inner) { }

        public UnprocessableEntityException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
