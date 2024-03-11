namespace Data.Models.ResponseModel;

public class ListDataOutput<T> : Response
{
    public ListDataOutput()
    {
        Data = new List<T>();
    }

    public int TotalRecord { get; set; }
    public List<T> Data { get; set; }
}

public class DataOutput<T> : Response
{
    public T? Data { get; set; }
}

public class ListDataOutputTicket<T> : ListDataOutput<T>
{
    public int TotalOrder { get; set; }
    public int TotalDesign { get; set; }
    public int TotalAccount { get; set; }
    public int TotalStore { get; set; }
    public int TotalWallet { get; set; }
    public int TotalProduct { get; set; }
    public int TotalSystem { get; set; }
    public int TotalOpen { get; set; }
    public int TotalProcess { get; set; }
    public int TotalClose { get; set; }
}

public class PostsDTO
{
    public int Id { get; set; }

    public int CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Thumbnail { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public int CategoryId { get; set; }
    public int Type { get; set; }
}