using MemberRegister.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RRMemberRegister.Client.Services
{
    public interface IMemberDataService
    {
        /// <summary>
        /// Metoden hämtar alla medlemmar
        /// </summary>
        /// <returns>Medlemmar</returns>
        Task<IEnumerable<Member>>GetMembers();

        /// <summary>
        /// Metoden hämtar sökt medlem
        /// </summary>
        /// <param name="id">Id för sökt medlem</param>
        /// <returns>Sökt medlem</returns>
        Task<Member> GetMember(int id);

        /// <summary>
        /// Metoden skapar en ny medlem
        /// </summary>
        /// <param name="member">Medlem objekt med information om nya medlemmen</param>
        /// <returns>Objekt med medlemmens information uppdaterad med det id som medlemen fick i repository</returns>
        Task<Member> CreateMember(Member member);

        /// <summary>
        /// Metoden uppdaterar information om en medlem
        /// </summary>
        /// <param name="member">Medlem objekt med information om medlemmen</param>
        /// <returns>Om uppdateringen gick bra returneras medlemens id från repository. Annars returneras ett negativt tal</returns>
        Task<int> UpdateMember(Member member);

        /// <summary>
        /// Metoden raderar uppgifter om en medlem
        /// </summary>
        /// <param name="member">Medlem objekt med information om medlememn</param>
        /// <returns>Om raderingen gick bra returneras medlemens id från repository. Annars returneras ett negativt tal</returns>
        Task<int> DeleteMember(Member member);

        /// <summary>
        /// Metoden raderar uppgifter om en medlem
        /// </summary>
        /// <param name="id">Id för den medlem som skall raderas</param>
        /// <returns>Om raderingen gick bra returneras medlemens id från repository. Annars returneras ett negativt tal</returns>
        Task<int> DeleteMember(int id);
    }
}