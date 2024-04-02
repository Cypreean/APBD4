using System;

namespace LegacyApp;

public class UserValidator
{
    public bool validateemail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }
    public bool validateName(string name,string lastName)
    {
        return string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName);
    }
    public bool validateAge(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
        return age >= 21;
    }
    public void CalculateCreditLimit(Client client, User user, IUserCreditService _userCreditService)
    {
        if(client.Type == "VeryImportantClient")
        {
            user.HasCreditLimit = false;
        }
        else if (client.Type == "ImportantClient")
        {
            user.HasCreditLimit = true;
            int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            user.CreditLimit = creditLimit*2;
        }
        else
        {
            user.HasCreditLimit = true;
            user.CreditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
        }
        
    }

    public bool ValidateCreditLimit(User user)
    {
        return (user.HasCreditLimit && user.CreditLimit < 500);
    }
    
    
  
    
}