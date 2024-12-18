namespace ZWTCampusCareerView.ViewModels
{
    public class ChangePasswordRequest
    {
        public string Username { get; set; }     // 用户名
        public string OldPassword { get; set; }  // 旧密码
        public string NewPassword { get; set; }  // 新密码
    }
}
