using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using GenericApi.Model.Contexts;
using GenericApi.Core.Settings;
using System;
using GenericApi.Services.Tests.Data;
using GenericApi.Bl.Mapper;

namespace GenericApi.Services.Tests.Fixtures
{

    public class ServicesTestsFixture : ServicesTestsData, IDisposable
    {
        private const string _dbName = "WorkShop2";
        private const string _jwtSecrect = "0263875b-b775-4426-938c-ab7c04c74b22";
        private const int _jwtExpires = 10;

        public DbContextOptionsBuilder<WorkShopContext> OptionsBuilder { get; private set; }

        public WorkShopContext Context { get; private set; }
        public IOptions<JwtSettings> Settings;
        public IMapper Mapper;

        public ServicesTestsFixture()
        {
            #region Automapper

            Mapper = new MapperConfiguration(x => x.AddProfile<MainMapperProfile>()).CreateMapper();

            #endregion

            #region Repository

            OptionsBuilder = new DbContextOptionsBuilder<WorkShopContext>();
            OptionsBuilder.UseInMemoryDatabase(_dbName);

            Context = new WorkShopContext(OptionsBuilder.Options);

            Context.Users.AddRange(_user1, _user2);
            Context.WorkShops.AddRange(_workShop1,_workShop2);
            Context.WorkShopDays.AddRange(_day1,_day2);
            Context.WorkShopMembers.AddRange(_workShopMember1, _workShopMember2);
            Context.Documents.AddRange(_document1,_document2);

            Context.SaveChanges();

            #endregion

            #region Option Settings

            Settings = Options.Create(new JwtSettings
            {
                ExpiresInMinutes = _jwtExpires,
                Secret = _jwtSecrect
            });

            #endregion

        }

        public void Dispose()
        {
        }
    }
}
