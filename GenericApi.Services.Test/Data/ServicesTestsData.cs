using GenericApi.Core.Enums;
using GenericApi.Model.Entities;
using System;

namespace GenericApi.Services.Tests.Data
{
    public class ServicesTestsData
    {
        public readonly User _user1 = new User
        {
            Name = "Emmanuel",
            MiddleName = "Enrique",
            LastName = "Jimenez",
            SecondLastName = "Pimentel",
            Dob = new DateTime(1996, 06, 16),
            DocumentType = DocumentType.ID,
            DocumentTypeValue = "22500851658",
            Gender = Gender.MALE,
            UserName = "emmanuel",
            Password = BCrypt.Net.BCrypt.HashPassword("Hola1234"),
            UserRole = UserRole.ADMIN
        };
        public readonly User _user2 = new User
        {
            Name = "Maryelin",
            MiddleName = "V",
            LastName = "Ramirez",
            SecondLastName = "Alvarez",
            Dob = new DateTime(2002, 11, 29),
            DocumentType = DocumentType.ID,
            DocumentTypeValue = "40232338166",
            Gender = Gender.FEMALE,
            UserName = "maryelinram",
            Password = BCrypt.Net.BCrypt.HashPassword("Hola1234"),
            UserRole = UserRole.USER
        };

        public readonly WorkShop _workShop1 = new WorkShop
        {
            Name = "Solvex WorkShop 1",
            Description = "We are here to practice a lot!",
            StartDate = new DateTime(2021, 06, 18),
            EndDate = null,
            ContentSupport = "https://github.com/EmmanuelJP/GenericApis",
        };
        public readonly WorkShop _workShop2 = new WorkShop
        {
            Name = "Solvex WorkShop 2",
            Description = "We are here to practice a lot!",
            StartDate = new DateTime(2021, 06, 18),
            EndDate = null,
            ContentSupport = "https://github.com/EmmanuelJP/GenericApis",
        };

        public readonly WorkShopDay _day1 = new WorkShopDay
        {
            Day = 0,
            Mode = 0,
            ModeLocation = "(Salón Coliseo de Solvex - https://g.page/solvexdo?share - Calle Eugenio Deschamps 6, Santo Domingo 10133)",
            StartHour = new TimeSpan(3, 0, 0),
            EndHour = null,
            WorkShopId = 1
        };
        public readonly WorkShopDay _day2 = new WorkShopDay
        {
            Day = 0,
            Mode = 0,
            ModeLocation = "(Salón Coliseo de Solvex - https://g.page/solvexdo?share - Calle Eugenio Deschamps 6, Santo Domingo 10133)",
            StartHour = new TimeSpan(3, 0, 0),
            EndHour = null,
            WorkShopId = 1
        };

        public readonly WorkShopMember _workShopMember1 = new WorkShopMember
        {
            Role = WorkShopMemberRole.STUDENT,
            WorkShopId = 1,
            UserId = 1,
        };
        public readonly WorkShopMember _workShopMember2 = new WorkShopMember
        {
            Role = WorkShopMemberRole.STUDENT,
            WorkShopId = 2,
            UserId = 2,
        };

        public readonly Document _document1 = new Document
        {
            FileName = "Documento 1",
            OriginalName = "Documento 1",
            ContentType = "Adobe Acrobat Document (.pdf)"
        };
        public readonly Document _document2 = new Document
        {
            FileName = "Documento 2",
            OriginalName = "Documento 2",
            ContentType = "Adobe Acrobat Document (.pdf)"
        };
    }
}