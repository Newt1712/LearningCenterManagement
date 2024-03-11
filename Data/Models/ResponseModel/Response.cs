using Data.Models.Common;

namespace Data.Models.ResponseModel;

public class Response
{
    public ResponseStatusCode StatusCode { get; set; }
    public string ErrorMessage { get; set; }
    public int Id { get; set; }
}

public class ResponseShopbase : Response
{
    public ulong? ShopbaseID { get; set; }
}

public class ResponseWoo : Response
{
    public ulong? LongWooID { get; set; }
}

public class ResponseShopify : Response
{
    public ulong? ShopifyID { get; set; }
}

public class ResponseImage : Response
{
    public string Url { get; set; }
}

public class ResponseDTO<T> : Response
{
    public T Data { get; set; }
}

public class SelectItem
{
    public int ID { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
}

public class ResponseList : Response
{
    public ResponseList()
    {
        Items = new List<ResponseListItem>();
    }

    public List<ResponseListItem> Items { get; set; }
}

public class ResponseListItem
{
    public int RowIndex { get; set; }
    public string Message { get; set; }
}

public class LoginResponse : Response
{
    public string UserName { get; set; }
    public string DisplayName { get; set; }
    public string Token { get; set; }

    public string UserCode { get; set; }
    //public DateTime ExpiredDate { get; set; }
}

public class UploadResponse
{
    public string FilePath { get; set; }
    public string FileUrl { get; set; }
}