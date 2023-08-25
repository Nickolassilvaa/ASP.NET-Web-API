using api.Data;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class UserReporitory : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;
        public UserReporitory(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }
        public async Task<List<UserModel>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<UserModel> CreateUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userById = await GetUserById(id);

            if (userById == null) throw new Exception($"Usuário {id} não encontrado");
            
            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }
        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetUserById(id);

            if (userById == null) throw new Exception($"Usuário {id} não encontrado");

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true; 
        }
    }
}
