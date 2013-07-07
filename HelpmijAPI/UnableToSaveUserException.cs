using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vdw.maxim.helpmijapi
{
    /// <summary>
    /// Unable to save user Exception
    /// </summary>
    public class UnableToSaveUserException : Exception
    {
        public UnableToSaveUserException()
        {
        }

        public UnableToSaveUserException(string message)
            : base(message)
        {
        }

        public UnableToSaveUserException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
