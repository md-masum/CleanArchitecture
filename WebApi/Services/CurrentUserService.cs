using System;
using System.Security.Claims;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(/*IHttpContextAccessor httpContextAccessor*/)
        {
            //UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            //Email = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
            //UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            //Phone = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.MobilePhone);
            UserId = "1";
            UserName = "admin";
            Email = "admin@gmail.com";
            Phone = "0123456789";
        }
        
        public string UserId { get; }
        public string UserName { get; }
        public string Email { get; }
        public string Phone { get; }
    }
}