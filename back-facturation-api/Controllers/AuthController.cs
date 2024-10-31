﻿using back_facturation_api.Data;
using back_facturation_api.Dtos;
using back_facturation_api.Helpers;
using back_facturation_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_facturation_api.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository _Repository;
        private readonly JwtService _JwtService;
        public AuthController(IUserRepository repository, JwtService jwtService) 
        {
            _Repository = repository;
            _JwtService = jwtService;
        }


        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            
            return Created("success", _Repository.Create(user));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _Repository.GetByEmail(dto.Email);
            
            // Check si le user existe
            if (user == null) return BadRequest(new { message = "Invalide Credentials"});
            
            // Check si le mot de passe est correct.
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { message = "Invalide Credentials"});
            }

            var jwt = _JwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "Logged in successfully"
            });
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {

                var jwt = Request.Cookies["jwt"];

                var token = _JwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _Repository.GetById(userId);

                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                message = "Disconnected successfully"
            });
        }
    }
}