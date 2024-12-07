namespace EAO.BL.DTOs.User
{
    public class UserDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }

    public class UserVM
    {
        public string UserName { get; set; } = string.Empty;
        public string Ar_name { get; set; } = string.Empty;
        public int? RoleId { get; set; }
        public int? GovId { get; set; }
        public int? RegionId { get; set; }
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
