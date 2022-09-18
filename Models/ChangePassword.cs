namespace Project.Models
{
    public class ChangePassword
    {
        public string Id { get; set; }    
        public string NewPassword { get; set; }
        public bool ConfirmPassword { get; set; } 
        public bool RememberMe { get; set; }    
        
    }
}
