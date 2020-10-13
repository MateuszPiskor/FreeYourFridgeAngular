using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FreeYourFridge.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeYourFridge.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        //private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            //_mapper = mapper;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
        public async Task<UserDetails> GetUserDetail(int id)
        {
            var userDetail = await _context.UsersDetails.FirstOrDefaultAsync(uD => uD.UserId == id);
            return userDetail;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async void UpdateUserDetails(UserDetails userToUpdate, int id)
        {
            var updateStudent = await _context.UsersDetails.FirstOrDefaultAsync(uD => uD.UserId == id);
            if (updateStudent == null)
            {
                userToUpdate.UserId = id;
                _context.Add(userToUpdate);
                _context.SaveChanges();
                return;
            }
            _context.SaveChanges();
        }
    }
}