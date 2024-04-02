using System;

namespace LegacyApp
{
    
    public class UserService
    {
        private IClientRepository _clientRepository;
        private IUserCreditService _userCreditService;
        private IUserRepository _userRepository;
        public UserService(IClientRepository clientRepository, IUserCreditService userCreditService, IUserRepository userRepository)
        {
            _clientRepository = clientRepository;
            _userCreditService = userCreditService;
            _userRepository = userRepository;
        }
       
        public UserService()
        {
            _clientRepository = new ClientRepository();
            _userCreditService = new UserCreditService();
            _userRepository = new UserRepositoryAdapter();
        }
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            UserValidator userValidator = new UserValidator();
            if (userValidator.validateName(firstName, lastName))
            {
                return false;
            }

            if (!userValidator.validateemail(email))
            {
                return false;
            }

            if (!userValidator.validateAge(dateOfBirth))
            {
                return false;
            }
            
            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            userValidator.CalculateCreditLimit(client, user, _userCreditService);
            if(userValidator.ValidateCreditLimit(user))
            {
                return false;
            }

            _userRepository.Add(user);
            return true;
        }
    }
}
