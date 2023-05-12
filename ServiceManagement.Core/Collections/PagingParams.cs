using ServiceManagement.Core.Contracts;

namespace ServiceManagement.Core.Collections;

public class PagingParams : IPagingParams
{
	public int? PageSize { get; set; } = 11;

	public int? PageNumber { get; set; } = 1;

	public string SortColumn { get; set; } = "Id";

	public string SortOrder { get; set; } = "ASC";
}
