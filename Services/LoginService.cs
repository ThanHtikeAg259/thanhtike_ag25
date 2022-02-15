//<copyright file ="LoginService.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/3/2021</date>

namespace POS_OJT.Services
{
    using POS_OJT.DAOs;

    /// <summary>
    /// Defines the <see cref="LoginService" />.
    /// </summary>
    public class LoginService
    {
        /// <summary>
        /// Defines the loginDAO.
        /// </summary>
        private LoginDAO loginDAO = new LoginDAO();

        /// <summary>
        /// The GetPassword.
        /// </summary>
        /// <param name="staff_number">The staff_number<see cref="string"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object GetPassword(string staff_number)
        {
            return loginDAO.GetPassword(staff_number);
        }

        /// <summary>
        /// The ValidatePassword.
        /// </summary>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <param name="correctHash">The correctHash<see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}
