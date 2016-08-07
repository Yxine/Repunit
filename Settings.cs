using System.Configuration;

/// <summary></summary>
// ReSharper disable once CheckNamespace
public static class Settings
{

	/// <summary></summary>
	public static int OutputIterval
	{
		get
		{
			var i = 12345;
			try
			{
				int.TryParse(ConfigurationManager.AppSettings["Interval.Output"], out i);
			}
			// ReSharper disable once EmptyGeneralCatchClause
			catch
			{
			}
			return i;
		}
	}

	/// <summary></summary>
	public static int SaveIterval
	{
		get
		{
			var i = 123456;
			try
			{
				int.TryParse(ConfigurationManager.AppSettings["Interval.Save"], out i);
			}
			// ReSharper disable once EmptyGeneralCatchClause
			catch
			{
			}
			return i;
		}
	}

}
