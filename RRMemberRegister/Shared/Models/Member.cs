﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;

namespace MemberRegister.Models
{
    /// <summary>
    /// Klass med information om en medlem
    /// </summary>
    public class Member
    {
        [Key]
        public int Id { get; set; } = 0;

        [Required]
        [DisplayName("Förnamn")]
        public string Fornamn { get; set; }

        [Required]
        [DisplayName("Efternamn")]
        public string Efternamn { get; set; }

        [Required]
        [DisplayName("Adress")]
        public string Adress { get; set; }

        [Required]
        [DisplayName("Postnummer")]
        public string Postnummer { get; set; }

        [Required]
        [DisplayName("Postort")]
        public string Postort { get; set; }

        [DisplayName("Skapat datum")]
        public DateTime Skapatdatum { get; set; }

        [DisplayName("Datum för senaste uppdateringen")]
        public DateTime Senastuppdateraddatum { get; set; }

        [NotMapped]
        [ScaffoldColumn(false)]
        [DisplayName("Skapat datum")]
        public string Skapatdatumasstring { get; set; }

        [NotMapped]
        [ScaffoldColumn(false)]
        [DisplayName("Namn")]
        public string Namn {
            get 
            {
                return this.Fornamn + " " + this.Efternamn;
            }
        }


        /// <summary>
        /// Används för att hantera felkoder från Webapi
        /// </summary>
        [NotMapped]
        [ScaffoldColumn(false)]
        public HttpStatusCode HttpStatusCode { get; set; }


        /// <summary>
        /// ToString metod som returnerar information om medlemmen
        /// </summary>
        /// <returns>Information om medlemen som en string</returns>
        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder("Id: " + this.Id);
            strBuild.Append(System.Environment.NewLine);

            strBuild.Append(this.Namn);
            strBuild.Append(System.Environment.NewLine);

            strBuild.Append(this.Adress);
            strBuild.Append(System.Environment.NewLine);

            strBuild.Append(this.Postnummer);
            strBuild.Append(" ");
            strBuild.Append(this.Postort);            

            strBuild.Append(System.Environment.NewLine);
            strBuild.Append("Skapat datum: " + this.Skapatdatumasstring);

            strBuild.Append(System.Environment.NewLine);
            strBuild.Append("Senast uppdaterad: " + this.Senastuppdateraddatum.ToShortDateString());

            return strBuild.ToString();
        }
    }
}