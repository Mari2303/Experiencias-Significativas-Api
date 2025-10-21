namespace Entity.Requests
{
    public class PermissionRequest : BaseRequest
    {
        
        public string Code { get; set; } = string.Empty;
       
        public string Name { get; set; } = string.Empty;
     
        public string Description { get; set; } = string.Empty;
    }
}
