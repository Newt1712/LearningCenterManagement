using System.ComponentModel;

namespace Data.Models.RequestModel;

public class Pager
{
    public int PageSize { get; set; } = 1;
    public int PageIndex { get; set; } = 10;
    [DefaultValue("Id")] public string? SortBy { get; set; } = "Id";
    [DefaultValue("desc")] public string? OrderBy { get; set; } = "desc";
    public string? Keyword { get; set; } = "";
    public bool? IsAdmin { get; set; } = false;
}

public class CategoryFilter : Pager
{
    public int Type { get; set; }
    public int? CategoryId { get; set; }
    public string? Slug { get; set; }
}

public class ActivityLogPager : Pager
{
    public bool IsByUser { get; set; }
    public string? UserName { get; set; }
}

public class QRCodeEntityPager : Pager
{
    public string PhoneNumber { get; set; }
}

public class ProductItemPager : Pager
{
    public int ProductID { get; set; }
}

public class StorePager : Pager
{
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}

public class ProductPager : Pager
{
    public int CategoryID { get; set; }
    public int Active { get; set; }
    public int ParentID { get; set; }
}

public class QuestionPager : Pager
{
    public int? QuestionType { get; set; }
    public int? SubjectId { get; set; }
}

public class QuestionFilter
{
    public int? SubjectId { get; set; }
    public string? Keyword { get; set; }
}

public class TestPager : Pager
{
    public int? TestStatus { get; set; }
    public string? Manager { get; set; }
    public int? GroupId { get; set; }
}

public class GroupPager : Pager
{
}

public class SubjectPager : Pager
{
    public int? GroupID { get; set; }
}

public class SessionDetailPager : Pager
{
    public int? SessionID { get; set; }
    public int? StatusID { get; set; }
    public int? TestID { get; set; }
    public string? EmployeeID { get; set; }
    public string? Manager { get; set; }
}

public class EmailTemplatePager : Pager
{
}

public class UserRequest
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? DisplayName { get; set; }
}