
namespace Hotel.Utils;

public class PaginationParams
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public int SkipCount
    {
        get
        {
            return (PageNumber - 1) * PageSize;
        }
    }

    public PaginationParams(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public PaginationParams()
    {
    }
}
