namespace EAO.BL.DTOs.User
{
    public class UserDto
    {
        public string UName { get; set; } = string.Empty;
        public string PWD { get; set; } = string.Empty;


    }
    public class UserVM
    {
        public string UName { get; set; } = string.Empty;
        public string ar_name { get; set; } = string.Empty;
        public int? roleId { get; set; }
        public int? govId { get; set; }
        public int? regionId { get; set; }
        public string Email { get; set; } = string.Empty;
        public long Id { get; set; }
        public string Token { get; set; } = string.Empty;





    }
    public class APIResponseViewModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        // public object Body { get; set; }
    }
}
