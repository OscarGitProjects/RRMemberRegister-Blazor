using RRMemberRegister.Shared.Enums;
using System;

namespace RRMemberRegister.Shared.Helpers
{
    /// <summary>
    /// Klass med hjälp metoder för ErrorCode
    /// </summary>
    public class ErrorCodeMessage
    {
        /// <summary>
        /// Metoden returnerar lämplig text beroende av enum ErrorCode
        /// </summary>
        /// <param name="code">enum ErrorCode som bestämmer texten som returneras</param>
        /// <returns>Lämplig text som kan vissas för användaren</returns>
        public static string GetErrorCodeMessage(ErrorCode code)
        {
            string strMessage = String.Empty;

            switch(code)
            {
                case ErrorCode.NONE:
                    strMessage = String.Empty;
                    break;
                case ErrorCode.CREATED:
                    strMessage = "Det gick inte skapa en ny medlem";
                    break;
                case ErrorCode.UPDATED:
                    strMessage = "Det gick inte uppdaterat uppgifter om en medlem";
                    break;
                case ErrorCode.DELETED:
                    strMessage = "Det gick inte radera medlemmen";
                    break;
                case ErrorCode.NOTFOUND:
                    strMessage = "Det gick inte hitta medlemmen";
                    break;
                default:
                    strMessage = String.Empty;
                    break;
            }

            return strMessage;
        }
    }
}
