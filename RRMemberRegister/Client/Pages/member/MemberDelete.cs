using MemberRegister.Models;
using Microsoft.AspNetCore.Components;
using RRMemberRegister.Client.Services;
using RRMemberRegister.Shared.Enums;
using RRMemberRegister.Shared.Helpers;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RRMemberRegister.Client.Pages.member
{
    public partial class MemberDelete
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
        /// Medlem som vi vill se information om
        /// </summary>
        public Member Member { get; set; }

        /// <summary>
        /// ErrorCode som sätts när det inte gick skapa en medlem. Då skall ett medelande om detta visas i view
        /// </summary>
        public ErrorCode ErrorValue { get; set; } = ErrorCode.NONE;


        protected override async Task OnInitializedAsync()
        {
            int iMemberId = 0;

            if (Int32.TryParse(this.MemberId, out iMemberId))
            {
                var data = await MemberDataService.GetMember(iMemberId);
                this.Member = data;

                if(data.HttpStatusCode == HttpStatusCode.NotFound)
                    ErrorValue = ErrorCode.NOTFOUND;
            }
            else
            {
                this.Member = new Member { Id = 0 };
            }

            //return base.OnInitializedAsync();
        }


        protected async Task OnSubmitForm()
        {
            int id = Member.Id;

            int iDeletedMemberId = await this.MemberDataService.DeleteMember(id);
            if (iDeletedMemberId <= 0)
            {
                this.ErrorValue = ErrorCode.DELETED;
            }
            else
            {
                NavigationManager.NavigateTo("/member/memberlist/" + MemberActionCodeConverter.ConvertToInt(MemberActionCode.DELETED));
            }
        }
    }
}
