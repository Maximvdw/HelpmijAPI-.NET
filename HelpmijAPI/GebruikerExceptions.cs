/*
 * Unofficial Helpmij.nl Aplication Interface
 * Copyright (C) 2009 Maxim Van de Wynckel <Maximvdw> and contributors
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mvdw.helpmijapi.gebruiker
{
    /// <summary>
    /// Unable to connect to helpmij
    /// </summary>
    public class UnableToConnectException : Exception
    {
        /// <summary>
        /// Unable to connect to helpmij
        /// </summary>
        /// <param name="message">Error Message</param>
        public UnableToConnectException(string message)
            : base(message)
        {
        }
    }

    /// <summary>
    /// Unable to save user Exception
    /// </summary>
    public class UnableToSaveUserException : Exception
    {
        /// <summary>
        /// Unable to save the user
        /// </summary>
        /// <param name="message">Error Message</param>
        public UnableToSaveUserException(string message)
            : base(message)
        {
        }
    }

    /// <summary>
    /// Credentials Wrong Exception
    /// </summary>
    public class CredentialsWrongException : Exception
    {
        /// <summary>
        /// Credentials are wrong
        /// </summary>
        /// <param name="message">Error Message</param>
        public CredentialsWrongException(string message)
            : base(message)
        {
        }
    }

    /// <summary>
    /// User Not logged in
    /// </summary>
    public class UserNotLoggedInException : Exception
    {
        /// <summary>
        /// User is not logged in
        /// </summary>
        /// <param name="message">Error Message</param>
        public UserNotLoggedInException(string message)
            : base(message)
        {
        }
    }
}
