/*
 * Created by Kenny.
 * User: Kenny
 * Date: 07/24/2019
 * Time: 15:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DrawingFinder
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Folder
	{
		public string folder_name { get; set; }
		public string location { get; set; }
		
		public Folder()
		{
		}
		
		public Folder(string _folder_name, string _location)
		{
			folder_name = _folder_name;
			location = _location;
		}
	}
	
	
}
