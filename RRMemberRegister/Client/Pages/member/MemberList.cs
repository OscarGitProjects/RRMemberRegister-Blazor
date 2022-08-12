using MemberRegister.Models;
using Microsoft.AspNetCore.Components;
using RRMemberRegister.Client.Services;
using RRMemberRegister.Shared.Enums;
using RRMemberRegister.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRMemberRegister.Client.Pages.member
{
    public partial class MemberList
    {
        [Inject]
        public IMemberDataService MemberDataService { get; set; }

        [Parameter]
        public string MemberAction { get; set; }

        /// <summary>
        /// Variabeln talar om det har skett ett anrop till IndexModel från en razor component som vill visa ett meddelande i component
        /// Meddelande visas om det har skapats en ny medlem, en medlems information har uppdaterats, en medlem har raderats
        /// 0 = ej satt värde, 1 = created, 2 = updated, 3 = deleted
        /// </summary>
        public MemberActionCode MemberActionValue { get; set; } = MemberActionCode.NONE;

        /// <summary>
        /// Lista med medlemmar som skall visas i component
        /// </summary>
        public List<Member> Members { get; set; }


        protected override async Task OnInitializedAsync()
        {
            int iMemberAction = 0;

            // Om det skall visas meddelanden om att ex att en medlem har raderats, uppdaterats eller skapats finns det ett värde på iMemberAction
            if (Int32.TryParse(this.MemberAction, out iMemberAction))
                this.MemberActionValue = MemberActionCodeConverter.ConvertToActionCode(iMemberAction);
            else
                this.MemberActionValue = MemberActionCodeConverter.ConvertToActionCode(iMemberAction);


            var data = await MemberDataService.GetMembers();
            if(data != null)
                this.Members = data.ToList<Member>();
        }
    }
}