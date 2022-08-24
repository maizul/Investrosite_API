//using BLL.BusinessEntity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using DAL;
//using DAL.Database;

//namespace BLL.Services
//{
//    public class AuthService
//    {
//        public AuthService()
//        {

//            new MapperConfiguration(cfg => {
//                cfg.CreateMap<Admin, AdminModel>();
//                cfg.CreateMap<AdminModel, Admin>();
//                cfg.CreateMap<Token, TokenModel>();
//                cfg.CreateMap<TokenModel, Token>();
//            });

//        }
//        public TokenModel Auth(string Email, string Password)
//        {
//            var config = new MapperConfiguration(cfg => {
//                cfg.CreateMap<Admin, AdminModel>();
//                cfg.CreateMap<AdminModel, Admin>();
//                cfg.CreateMap<Token, TokenModel>();
//                cfg.CreateMap<TokenModel, Token>();
//            });

//            var mappe1 = new Mapper(config);
//            // var user_data = mappe1.Map<Manager>(user);
//            var mapper = new Mapper(config);
//            var data = mapper.Map<TokenModel>(new AuthRepo().Authenticate(Email, Password));
//            return data;
//        }
//        public bool CheckValidityToken(string token)
//        {
//            var a = new AuthRepo();
//            var rs = a.IsAuthenticated(token);
//            return rs;
//        }
//    }
//}
