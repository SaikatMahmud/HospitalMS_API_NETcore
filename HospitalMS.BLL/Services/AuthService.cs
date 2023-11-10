using AutoMapper;
using HospitalMS.BLL.DTOs;
using HospitalMS.DAL;
using HospitalMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.Services
{
    public class AuthService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public AuthService(ApplicationDbContext db)
        {
            _dataAccessFactory = new DataAccessFactory(db);
        }
        public  TokenDTO Authenticate(string Username, string Password)
        {
            var res = _dataAccessFactory.AuthData().Authenticate(Username, Password); //true if uname & pass matched,
                                                                                     //then generate token and return the token to the user

            if (res == true)
            {
                var allTkn = _dataAccessFactory.TokenData().Get();
                var exTkn = (from t in allTkn
                             where t.CreatedBy.Equals(Username) &&
                             t.ExpiredAt == null
                             select t).SingleOrDefault();
                if (exTkn != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(exTkn);
                }
                else
                {
                    var token = new Token();
                    token.CreatedBy = Username;
                    token.CreatedAt = DateTime.Now;
                    token.TKey = Guid.NewGuid().ToString();
                    var ret = _dataAccessFactory.TokenData().Add(token);
                    if (ret != null)
                    {
                        var cfg = new MapperConfiguration(c =>
                        {
                            c.CreateMap<Token, TokenDTO>();
                        });
                        var mapper = new Mapper(cfg);
                        return mapper.Map<TokenDTO>(ret);
                    }
                }
            }
            return null;
        }
        public  TokenDTO IsTokenValid(string tkey)//return token obj
        {
            var extk = _dataAccessFactory.TokenData().Get(t=> t.TKey == tkey);
            if (extk != null && extk.ExpiredAt == null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Token, TokenDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<TokenDTO>(extk);
            }
            return null;
        }
        public  string TokenUserType(string tkey)//return token User type
        {
            var token = IsTokenValid(tkey);
            if (token != null)
            {
                var user = _dataAccessFactory.UserData().Get(u=> u.Username == token.CreatedBy);
                return user.Type.ToString();
            }
            return null;
        }
        public  bool Logout(string tkey)
        {
            var extk = _dataAccessFactory.TokenData().Get(t=> t.TKey == tkey);
            extk.ExpiredAt = DateTime.Now;
            if (_dataAccessFactory.TokenData().Update(extk) != null) return true;
            return false;

        }
        public  int TokenUserId(string tkey)//return token User id, for leave application
        {
            var token = IsTokenValid(tkey);

            var user = _dataAccessFactory.StaffData().Get(s=> s.Username == token.CreatedBy);
            //var user = (from s in allStaff
            //            where s.Username.Equals(token.CreatedBy)
            //            select s).SingleOrDefault();

            return user.Id;
        }
    }
}
