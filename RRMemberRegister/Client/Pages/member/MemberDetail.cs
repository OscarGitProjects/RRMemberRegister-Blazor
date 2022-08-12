using MemberRegister.Models;
using Microsoft.AspNetCore.Components;
using RRMemberRegister.Client.Services;
using System;
using System.Threading.Tasks;

namespace RRMemberRegister.Client.Pages.member
{
    public partial class MemberDetail
    {
        [Inject]
        public IMemberDataService MemberDataService { get; set; }

        /// <summary>
        /// Id för sökt medlem
        /// </summary>
        [Parameter]
        public string MemberId { get; set; }

        /// <summary>
        /// Medlem som vi vill se information om
        /// </summary>
        public Member Member { get; set; }


        protected override async Task OnInitializedAsync()
        {
            int iMemberId = 0;
          
            if (Int32.TryParse(this.MemberId, out iMemberId))
            {
                var data = await MemberDataService.GetMember(iMemberId);
                if(data != null)
                    this.Member = data;
            }
            else
            {
                this.Member = new Member { Id = 0 };
            }

            //return base.OnInitializedAsync();
        }
    }
}
