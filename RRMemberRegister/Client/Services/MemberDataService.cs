using MemberRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace RRMemberRegister.Client.Services
{
    /// <summary>
    /// Service klass för ett WebApi för medlemmar
    /// </summary>
    public class MemberDataService : IMemberDataService
    {
        /// <summary>
        /// HttpClient object som används för att anropa WebApi
        /// </summary>
        public HttpClient m_HttpClient { get; }


        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="httpClient">Reference till HttpClient</param>
        public MemberDataService(HttpClient httpClient)
        {
            m_HttpClient = httpClient;
        }


        /// <summary>
        /// Metoden skapar en ny medlem
        /// </summary>
        /// <param name="member">Medlem objekt med information om nya medlemmen</param>
        /// <returns>Objekt med medlemmens information uppdaterad med det id som medlemen fick i repository.
        /// Om något gick fel retuneras Member utan information med Statuscode satt i HttpStatusCode</returns>
        /// <exception cref="System.ArgumentNullException">Kastas om referensen till medlemen är null</exception> 
        public async Task<Member> CreateMember(Member member)
        {
            if (member == null)
                throw new ArgumentNullException("MemberDataService->Createmember(). Referensen till member är null");

            Member mem = null;
            HttpResponseMessage response = await m_HttpClient.PostAsJsonAsync("api/member", member);
            if (response.IsSuccessStatusCode)
            {
                mem = await response.Content.ReadFromJsonAsync<Member>();
                mem.HttpStatusCode = response.StatusCode;
            }

            if(response.StatusCode == HttpStatusCode.BadRequest)
            {// Vi fick en BadRequest tillbaka. Skapa en Medlem med uppgift om detta
                mem = new Member();
                mem.HttpStatusCode = response.StatusCode;
            }

            return mem;
        }


        /// <summary>
        /// Metoden raderar uppgifter om en medlem
        /// </summary>
        /// <param name="id">Referens till Member objekt med Id för medlemen som skall raderas</param>
        /// <returns>Om raderingen gick bra returneras medlemens id från repository. Annars returneras ett negativt tal</returns>
        /// <exception cref="System.ArgumentNullException">Kastas om referensen till medlemen är null</exception> 
        public async Task<int> DeleteMember(Member member)
        {
            if (member == null)
                throw new ArgumentNullException("MemberDataService->DeleteMember(). Referensen till member är null");

            return await DeleteMember(member.Id);
        }


        /// <summary>
        /// Metoden raderar uppgifter om en medlem
        /// </summary>
        /// <param name="member">Medlem objekt med information om medlememn</param>
        /// <returns>Om raderingen gick bra returneras medlemens id från repository. Annars returneras ett negativt tal</returns>
        /// <exception cref="System.ArgumentException">Kastas om id <= 0</exception>
        public async Task<int> DeleteMember(int id)
        {
            if (id <= 0)
                throw new ArgumentException("MemberDataService->DeleteMember(). Ogiltigt id. Id <= 0");

            int iDeletedMemberId = 0;
            
            HttpResponseMessage response = await m_HttpClient.DeleteAsync("api/member/" + id);
            if (response.IsSuccessStatusCode)
            {
                iDeletedMemberId = await response.Content.ReadFromJsonAsync<int>();
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                iDeletedMemberId = -1;
            }

            return iDeletedMemberId;
        }


        /// <summary>
        /// Metoden hämtar sökt medlem
        /// </summary>
        /// <param name="id">Id för sökt medlem</param>
        /// <returns>Sökt medlem.
        /// Om något gick fel retuneras Member utan information med Statuscode satt i HttpStatusCode</returns>
        /// <exception cref="System.ArgumentException">Kastas om id <= 0</exception>
        public async Task<Member> GetMember(int id)
        {
            if (id <= 0)
                throw new ArgumentException("MemberDataService->GetMember(). Ogiltigt id. Id <= 0");

            Member mem = null;

            HttpResponseMessage response = await m_HttpClient.GetAsync("api/member/" + id);
            if (response.IsSuccessStatusCode)
            {
                mem = await response.Content.ReadFromJsonAsync<Member>();
                mem.HttpStatusCode = response.StatusCode;
            }            

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                mem = new Member();
                mem.Id = 0;
                mem.HttpStatusCode = response.StatusCode;
            }

            return mem;
        }


        /// <summary>
        /// Metoden hämtar alla medlemmar
        /// </summary>
        /// <returns>List med Medlemmar</returns>
        public async Task<IEnumerable<Member>> GetMembers()
        {
            List<Member> lsMembers = null;

            HttpResponseMessage response = await m_HttpClient.GetAsync("api/member");
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                if (!String.IsNullOrWhiteSpace(content))
                {
                    if (content.StartsWith("[{") && content.EndsWith("}]"))
                    {// Vi har en array av json objekt
                        lsMembers = JsonConvert.DeserializeObject<List<Member>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None });
                    }
                    else if (content.StartsWith("{") && content.EndsWith("}"))
                    {// Vi har bara ett json objekt
                        Member mem = JsonConvert.DeserializeObject<Member>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None });
                        lsMembers = new List<Member>();
                        lsMembers.Add(mem);
                    }
                }
            }               

            return lsMembers;
        }


        /// <summary>
        /// Metoden uppdaterar information om en medlem
        /// </summary>
        /// <param name="member">Medlem objekt med information om medlemmen</param>
        /// <returns>Om uppdateringen gick bra returneras medlemens id från repository. Annars returneras ett negativt tal</returns>
        /// <exception cref="System.ArgumentNullException">Kastas om referensen till medlemen är null</exception>        
        public async Task<int> UpdateMember(Member member)
        {
            if (member == null)
                throw new ArgumentNullException("MemberDataService->UpdateMember(). Referensen till member är null");

            int iUpdatedMemberId = 0;
            HttpResponseMessage response = await m_HttpClient.PutAsJsonAsync("api/member/" + member.Id, member);
            if (response.IsSuccessStatusCode)
            {
                iUpdatedMemberId = await response.Content.ReadFromJsonAsync<int>();
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                iUpdatedMemberId = -1;
            }

            return iUpdatedMemberId;
        }
    }
}