﻿using RankingApp.Model;

namespace RankingApp.Database
{
    public interface IUserRepository
    {
        User Create(User user); 
    }
}
