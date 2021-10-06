﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFPassword_Kata.Domain.Models;

public interface ITokenService {
    string GenerateToken(User user);
    bool CheckToken(string token);
}