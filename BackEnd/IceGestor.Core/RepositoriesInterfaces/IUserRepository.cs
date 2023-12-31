﻿using IceGestor.Core.Entities;

namespace IceGestor.Core.RepositoriesInterfaces;
public interface IUserRepository
{
    //Commands
    Task AddAsync(User user);
    void Update(User user);

    //Queries
    Task<bool> ExistsUserWithEmail(string email);
    Task<bool> ExistsUserWithUsername(string username);
    Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    Task<User> GetUserById(int id);
}
