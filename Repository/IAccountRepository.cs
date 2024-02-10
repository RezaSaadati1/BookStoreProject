using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUp(SignUpDto signUpDto);
        Task<string> Login(LoginDto loginDto);
    }
}