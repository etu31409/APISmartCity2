namespace APISmartCity.Controllers.Model
{
    public class User
    {
        public string UserName{get; set;}
        public string Password{get;set;}
        public string Email{get;set;}
        public int Id{get;set;}

        public User(){
        }

        public User(string userName, string email, int id, string password){
            this.UserName = userName;
            this.Email = email;
            this.Id = id;
            this.Password = password;
        }
    }

}