namespace Assets.HellaHotel.Scripts.DBServices
{
    public class ServerInfo
    {
        public static string Host = "http://localhost:5195/";


        #region controller
        public static string User = nameof(User);
        #endregion

        #region Function 
        public static string GetAll = nameof(GetAll);
        public static string GetById = nameof(GetById);
        public static string Create = nameof(Create);
        public static string Update = nameof(Update);
        public static string Delete = nameof(Delete);
        public static string UpdateRange = nameof(UpdateRange);
        public static string Registration = nameof(Registration);
        public static string Authorization = nameof(Authorization);
        #endregion
        public static string CreateRequestURL(string host, string controller, string method) => host
            + controller
            + "/" +
            method;


    }
}
