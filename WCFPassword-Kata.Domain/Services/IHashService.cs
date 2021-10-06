using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public interface IHashService {
    string ComputeHash(byte[] bytesToHash, byte[] salt);
    string GenerateSalt();
}