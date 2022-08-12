using RRMemberRegister.Shared.Enums;

namespace RRMemberRegister.Shared.Helpers
{
    /// <summary>
    /// Klass för att konvertera enum MemberActionCode till int eller visa versa
    /// </summary>
    public class MemberActionCodeConverter
    {
        /// <summary>
        /// Metod som konverterar siffra till MemberActionCode
        /// Det finns konvertering för tal 1 till 3. Allt annat blir konverterat till MemberActionCode.NONE
        /// </summary>
        /// <param name="iAction">siffra som skall konverteras till MemberActionCode</param>
        /// <returns>enum MemberActionCode</returns>
        public static MemberActionCode ConvertToActionCode(int iAction)
        {
            MemberActionCode actionCode = MemberActionCode.NONE;

            switch (iAction)
            {
                case 0:
                    actionCode = MemberActionCode.NONE;
                    break;
                case 1:
                    actionCode = MemberActionCode.CREATED;
                    break;
                case 2:
                    actionCode = MemberActionCode.UPDATED;
                    break;
                case 3:
                    actionCode = MemberActionCode.DELETED;
                    break;
                default:
                    actionCode = MemberActionCode.NONE;
                    break;
            }

            return actionCode;
        }


        /// <summary>
        /// Metod som konverterar MemberActionCode till siffra
        /// </summary>
        /// <param name="actionCode">MemberActionCode som skall konverteras till siffra</param>
        /// <returns>Siffra för anget MemberActionCode</returns>
        public static int ConvertToInt(MemberActionCode actionCode)
        {
            int code = 0;

            switch (actionCode)
            {
                case MemberActionCode.NONE:
                    code = 0;
                    break;
                case MemberActionCode.CREATED:
                    code = 1;
                    break;
                case MemberActionCode.UPDATED:
                    code = 2;
                    break;
                case MemberActionCode.DELETED:
                    code = 3;
                    break;
                default:
                    code = 0;
                    break;
            }

            return code;
        }
    }
}
