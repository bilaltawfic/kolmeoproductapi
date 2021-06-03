namespace KolmeoProductApi.Services.Options
{
	/// <summary>
	/// Represents the options to list all products.
	/// </summary>
	public class ProductListOptions
	{
		private const int defaultPageNumber = 1;
		private const int defaultPageSize = 50;
		private const int maxPageSize = 100;

		private int _pageNumber = defaultPageNumber;
		/// <summary>
		/// The page number to retrieve.
		/// </summary>
		public int PageNumber
		{
			get
			{
				return _pageNumber;
			}
			set
			{
				if (value < 1)
				{
					_pageNumber = defaultPageNumber;
					return;
				}

				_pageNumber = value;
			}
		}

		private int _pageSize = defaultPageSize;
		/// <summary>
		/// The number of items to retrieve per page.
		/// </summary>
		public int PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				if (value > maxPageSize)
				{
					_pageSize = maxPageSize;
					return;
				}

				if (value < 1)
				{
					_pageSize = defaultPageSize;
					return;
				}

				_pageSize = value;
			}
		}
	}
}
