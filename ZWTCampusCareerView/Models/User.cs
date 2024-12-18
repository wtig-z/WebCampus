namespace ZWTCampusCareerView.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty; // 添加默认值
        public string Email { get; set; } = string.Empty;    // 添加默认值
        public string Password { get; set; } = string.Empty; // 添加默认值
    }
}
