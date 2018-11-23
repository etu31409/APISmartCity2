namespace APISmartCity.Controllers
{
    public class User
    {
        public string Login{get; set;}
        public string MDP{get;set;}

        public User(string login, string mdp){
            this.Login = login;
            this.MDP = mdp;
        }
    }

}