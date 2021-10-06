using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFPassword_Kata.Services.Models;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService {
    [OperationContract]
    bool AreValidUserCredentials(User user);

    [OperationContract]
    bool SendResetEmail(string email);
    [OperationContract]
    void AddUser(User user);
}