using System;
using System.Collections.Generic;
using System.Text;
using TSTB.DAL.Models.CallBacks;
using TSTB.DAL.Models.Enums;

namespace TSTB.DAL.Models.User
{
    public class Organization
    {
        public int Id { get; set; }
        public string TaxCode { get; set; }
        /// <summary>
        /// Название организации
        /// </summary>
        public string NameOrganization { get; set; }

        /// <summary>
        /// Сфера деятельности
        /// </summary>
        public string Activity { get; set; }

        /// <summary>
        /// Адрес организации
        /// </summary>
        public string AddressOrganization { get; set; }

        /// <summary>
        /// Номер телефона организации
        /// </summary>
        public string PhoneOrganization { get; set; }

        /// <summary>
        /// Дата вступления в сппт
        /// </summary>
        public DateTime MembershipDate { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public Sex Sex { get; set; }

        public int CityId { get; set; }

        public Cities Cities { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        public string BirthPlace { get; set; }

        /// <summary>
        /// Номер и серия паспорта
        /// </summary>
        public string PassportSN { get; set; }

        /// <summary>
        /// Кем выдан паспорт
        /// </summary>
        public string IssuedBy { get; set; }

        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        public DateTime IssuedDate { get; set; }

        /// <summary>
        /// Место прописки
        /// </summary>
        public string PlaceRegistration { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
