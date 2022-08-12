using MemberRegister.Models;
using Microsoft.AspNetCore.Components;
using RRMemberRegister.Client.Services;
using RRMemberRegister.Shared.Enums;
using RRMemberRegister.Shared.Helpers;
using System.Net;
using System.Threading.Tasks;

namespace RRMemberRegister.Client.Pages.member
{
    public partial class MemberCreate
    {
        [Inject]
        public IMemberDataService MemberDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// Id för sökt medlem
        /// </summary>
        [Parameter]
        public string MemberId { get; set; }

        /// <summary>
        /// Medlem som jag vill skapa
        /// </summary>
        public Member Member { get; set; }

        /// <summary>
        /// ErrorCode som sätts när det inte gick skapa en medlem. Då skall ett medelande om detta visas i view
        /// </summary>
        public ErrorCode ErrorValue { get; set; } = ErrorCode.NONE;


        protected override Task OnInitializedAsync()
        {
            // Skapa en default member
            Member = new Member();
            Member.Id = 0;

            return base.OnInitializedAsync();
        }

        protected async Task OnValidSubmitForm()
        {            
            Member mem = await this.MemberDataService.CreateMember(this.Member);

            if (mem?.HttpStatusCode == HttpStatusCode.BadRequest)
            {
                this.ErrorValue = ErrorCode.CREATED;
            }
            else
            {
                NavigationManager.NavigateTo("/member/memberlist/" + MemberActionCodeConverter.ConvertToInt(MemberActionCode.CREATED));
            }
        }

        protected async Task OnInvalidSubmitForm()
        {
        }
    }
}
