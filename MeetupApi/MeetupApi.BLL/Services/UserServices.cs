
using AutoMapper;
using MeetupApi.BLL.DTO;
using MeetupApi.BLL.Interfaces;
using MeetupApi.DAL.Entities;
using MeetupApi.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using MeetupApi.BLL.Infrastructure;

namespace MeetupApi.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<UserDTO> _passwordHasher;

        public UserService(IUserRepository userRepository,IMapper mapper, IPasswordHasher<UserDTO> passwordHasher)
        {
            _userRepository = userRepository
                ?? throw new ArgumentNullException();
            _mapper = mapper
                ?? throw new ArgumentNullException();
            _passwordHasher = passwordHasher 
                ?? throw new ArgumentNullException();
        }

        public async Task<UserDTO> Register(UserDTO userDTO)
        {
            try
            {
                var validator = new RegisterUserValidator();
                var result = validator.Validate(userDTO);
                if (!result.IsValid)
                {
                    throw new FluentValidation.ValidationException("The entry is incorrect");
                }

                if (await _userRepository.GetUserByName(userDTO.Email) != null)
                {
                    throw new FluentValidation.ValidationException("A user with this name already exists.");
                }

                var user = new User
                {
                    Email = userDTO.Email,
                    PasswordHash = _passwordHasher.HashPassword(null, userDTO.Password)
                };

                await _userRepository.RegisterUser(user);
                return userDTO;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public async Task<bool> Authenticate(string name, string password)
        {

            var user = await _userRepository.GetUserByName(name);
            var userDto = _mapper.Map<UserDTO>(user);

            if (user != null && _passwordHasher.VerifyHashedPassword(userDto, user.PasswordHash, password) == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success)
            {
                return true;
            }

            return false;
        }
    }
}
