﻿using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using Entity.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using ResetPasswordRequest = Entity.Requests.Email.ResetPasswordRequest;
using ForgotPasswordRequest = Entity.Requests.Email.ForgotPasswordRequest;

namespace API.Controllers
{
    public class UserController : BaseModelController<User, UserDTO, UserRequest>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IBaseModelService<User, UserDTO, UserRequest> baseService, IUserService service, IMapper mapper) : base(baseService, mapper)
        {
            _userService = service;
            _mapper = mapper;
        }


        /// <summary>
        /// Obtener un usuario por nombre
        /// </summary>
        ///     
        [Authorize]
        [HttpGet("{username}")]
        public async Task<IActionResult> GetByName(string username)
        {
            try
            {
                var user = await _userService.GetByName(username);
                if (user == null)
                    return NotFound(new { message = "Usuario no encontrado" });

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }


        [Authorize]
        [HttpGet("{userId}/menu")]
        public async Task<ActionResult<List<MenuRequest>>> GetMenu(int userId)
        {
            var menu = await _userService.GetMenuAsync(userId);
            return Ok(menu);
        }





        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            await _userService.SendRecoveryCodeAsync(request.Email);
            return Ok("Correo de recuperación enviado.");
        }




        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            await _userService.ResetPasswordAsync(request.Email, request.Code, request.NewPassword);
            return Ok("Contraseña actualizada correctamente.");
        }



    }
}
