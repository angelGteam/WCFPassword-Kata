using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Security.Cryptography;

public class Service : IService {
    public bool AreValidUserCredentials(User user) {
        throw new NotImplementedException();
    }
    public bool SendResetEmail(string email) {
        throw new NotImplementedException();
    }
}