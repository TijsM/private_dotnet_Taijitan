﻿using System;
using System.Collections.Generic;
using System.Text;
using Taijitan.Models.Domain;

namespace TaijitanTest.Data
{
    public class DummyApplicationDbContext
    {
        #region Fields
        private readonly City _gent;
        private readonly City _antwerpen;
        private readonly City _brussel;
        private readonly IEnumerable<User> _users;
        private readonly Member _jarne;
        private readonly Member _robbe;
        private readonly Member _stef;
        private readonly Member _tijs;
        #endregion

        #region Properties
        public IEnumerable<City> Cities => new List<City> { _gent, _antwerpen, _brussel };
        public IEnumerable<User> Users => _users;
        public IEnumerable<Member> UsersFormula1 { get; set; }
        public Member UserTomJansens { get;  }
        public City TomJansensCity { get; set; }
        public IEnumerable<User> UsersByPartOfName { get; set; }
        public TrainingDay Dinsdag { get; set; }
        public IEnumerable<Formula> DinsdagFormule { get; set; }
        public IEnumerable<TrainingDay> TrainingsDays { get; set; }
        public Session Session1 { get; set; }
        public IEnumerable<Session> Sessions { get; set; }
        public IEnumerable<Formula> Formulas { get; set; }
        public IEnumerable<Member> Members { get; set; }
        public Admin Alain { get; set; }
        public NonMember NonMemberBernard { get; set; }
        public IEnumerable<NonMember> NonMembers { get; set; }
        public Teacher Teacher1 { get; set; }
        public Formula DinDon { get; set; }
        public Formula DinZat { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public CourseMaterial CourseMaterial { get; set; }
        public Comment CommentWithId1 { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<CourseMaterial> CourseMaterials { get; set; }
        #endregion



        #region Constructors
        public DummyApplicationDbContext()
        {
            _gent = new City("9000", "Gent");
            _antwerpen = new City("2000", "Antwerpen");
            _brussel = new City("1000", "Brussel");
            TomJansensCity = _gent;


            Dinsdag = new TrainingDay("Dinsdag", 18.00, 20.00, DayOfWeek.Tuesday);
            TrainingDay woensdag = new TrainingDay("Woensdag", 14.00, 15.50, DayOfWeek.Wednesday);
            TrainingDay donderdag = new TrainingDay("Donderdag", 18.00, 20.00, DayOfWeek.Thursday);
            TrainingDay zaterdag = new TrainingDay("Zaterdag", 10.00, 11.50, DayOfWeek.Saturday);
            TrainingDay zondag = new TrainingDay("Zondag", 11.00, 12.50, DayOfWeek.Sunday);

            TrainingsDays = new List<TrainingDay>
            {
                Dinsdag, woensdag, donderdag, zaterdag, zondag
            };

            DinDon = new Formula("dinsdag en donderdag", new List<TrainingDay> { Dinsdag, donderdag });
            DinZat = new Formula("dinsdag en zaterdag", new List<TrainingDay> { Dinsdag, zaterdag });
            Formula woeZat = new Formula("woensdag en zaterdag", new List<TrainingDay> { woensdag, zaterdag });
            Formula woe = new Formula("woensdag", new List<TrainingDay> { woensdag });
            Formula zat = new Formula("zaterdag", new List<TrainingDay> { zaterdag });
            Formula activiteit = new Formula("deelname aan activiteit", new List<TrainingDay>());
            Formula stage = new Formula("deelname aan meerdaagse stage", new List<TrainingDay>());

            Formulas = new List<Formula>
            {
                DinDon, DinZat, woeZat, woe, zat/*, activiteit, stage*/
            };

            DinsdagFormule = new List<Formula>
            {
                DinDon, DinZat
            };

            _tijs = new Member("Martens", "Tijs", new DateTime(1999, 6, 14), "Unknown", _brussel, Country.Belgium, "Unknown", "0499721771", "tijs.martens@student.hogent.be", DinDon, new DateTime(2014/06/2), Gender.Man, Country.Belgium, "14-06-1999.306-37", "Gent");
            _stef = new Member("Verlinde", "Stef", new DateTime(1999, 4, 25), "Unknown", _antwerpen, Country.Belgium, "Unknown", "0000000000", "stef.verlinde@student.hogent.be", DinZat, new DateTime(2015 / 08 / 4), Gender.Man, Country.Belgium, "02-08-1998.306-37", "Gent");
            _jarne = new Member("Deschacht", "Jarne", new DateTime(1999, 8, 9), "Zilverstraat", _gent, Country.Belgium, "16", "0492554616", "jarne.deschacht@student.hogent.be", woeZat, new DateTime(2016 / 01 / 30), Gender.Man, Country.Belgium, "09-08-1999.400-08", "Gent");
            _robbe = new Member("Dekien", "Robbe", new DateTime(1998, 8, 26), "Garzebekeveldstraat", _gent, Country.Belgium, "Unknown", "0000000000", "robbe.dekien@student.hogent.be", woe, new DateTime(2016 / 05 / 30), Gender.Man, Country.Belgium, "02-06-1999.100-20", "Gent");
            UserTomJansens = new Member("Jansens", "Tom", new DateTime(1999, 8, 9), "Hoogstraat", _gent, Country.Belgium, "8", "+32499854775", "tom.jansens@gmail.com",woeZat, new DateTime(2017 / 05 / 18), Gender.Man, Country.Belgium, "09-08-1999.400-09", "Gent");
            Alain = new Admin("Alain", "Vandamme", new DateTime(1980, 1, 15), "StationStraat", _antwerpen, Country.Belgium, "15", "+3249981557", "alain.vandamma@synalco.be", new DateTime(2005 / 01 / 30), Gender.Man, Country.Belgium, "14-06-1999.306-37", "Gent");

            Teacher1 = new Teacher("Chan", "Jacky", new DateTime(1960, 10, 18), "HongkongStreet", _gent, Country.Belgium, "1", "+23456987447", "jacky.chan@hollywood.com", new DateTime(2005 / 01 / 30), Gender.Man, Country.Belgium, "14-06-1999.306-37", "Gent");

            _users = new List<User>
            {
                UserTomJansens,Alain,
                _robbe,_jarne,_stef,_tijs,Teacher1

            };

            Images = new List<Image>
            {
                new Image("test1","test"),
                new Image("test2","test"),
                new Image("test3","test"),
                new Image("test4","test"),

            };
            CourseMaterial = new CourseMaterial(Rank.Kyu6, "testURL", "testtest", Images, "test") { MaterialId = 1};
            CourseMaterials = new List<CourseMaterial>
            {
                CourseMaterial,
                new CourseMaterial(Rank.Kyu6, "testURL", "testtest",Images, "kweetnie"),
                new CourseMaterial(Rank.Kyu6, "testURL", "testtest",Images, "test"),
                new CourseMaterial(Rank.Kyu6, "testURL", "testtest",Images, "test"),
        };

            CommentWithId1 = new Comment("content", CourseMaterial, UserTomJansens) { CommentId = 1};
            Comments = new List<Comment>()
            {
                CommentWithId1,
                new Comment("test",CourseMaterial,UserTomJansens){ CommentId = 2},
                new Comment("test",CourseMaterial,UserTomJansens){ CommentId = 3},
                new Comment("test",CourseMaterial,UserTomJansens){ CommentId = 4},
                new Comment("test",CourseMaterial,UserTomJansens){ CommentId = 5},
                new Comment("test",CourseMaterial,UserTomJansens){ CommentId = 6,IsRead = true},
            };

            Members = new List<Member>
            {
                _tijs, _stef, _jarne, _robbe
            };

            UsersFormula1 = new List<Member> {
                _robbe,_jarne,UserTomJansens
            };
            UsersByPartOfName = new List<Member> {
                _robbe,_jarne,_stef
            };
            Session1 = new Session(Formulas, Teacher1, Members) { SessionId = 0};
            Session1.AddToMembersPresent(_jarne);
            Session1.AddToMembersPresent(_tijs);
            Session1.AddToMembersPresent(_robbe);
            Sessions = new List<Session> { Session1 };

            NonMemberBernard = new NonMember("Bernard", "Deploige", "bernarddeploige@hotmail.com", Session1.SessionId);
            NonMember nonMemberJordy = new NonMember("Jordy", "de Tier", "jordydetier@hotmail.com", Session1.SessionId);
            NonMembers = new List<NonMember>
            {
                  NonMemberBernard, nonMemberJordy
            };
        }
        #endregion
    }
}
