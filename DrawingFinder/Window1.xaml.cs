/*
 * Created by Kenny.
 * User: drawings
 * Date: 24/07/2019
 * Time: 12:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;

namespace DrawingFinder
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		List<Folder> folders = new List<Folder>();
		string results;

		public Window1()
		{
			InitializeComponent();

			textbox1.Focus();

			textbox1.KeyDown += Textbox1_KeyDown;

		}

		private void Textbox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter) {
				Search();
			}
		}

		void Search()
		{
			datagrid1.IsReadOnly = true;

			string search = textbox1.Text;

			if (search.Length == 0) {
				MessageBox.Show("Please type in the Search Field");
                
			} else {
				folders = SqliteDataAccess.LoadFolders(search);
                
				resultsLabel.Content = folders.Count;

				if (folders.Count == 0) {
					resultsLabel.Content = folders.Count;
					MessageBox.Show("No Results Found");
				} else {
					results = string.Format("Results: {0}", folders.Count);
                	
					resultsLabel.Content = results;
                	     	
					datagrid1.Items.Clear();

					for (int i = 0; i < folders.Count; i++) {
						datagrid1.Items.Add(new Folder {
							folder_name = folders[i].folder_name.ToString(),
							location = folders[i].location.ToString()
						});
					}
				}


			}


		}

		private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
		{
			var test = (Folder)datagrid1.SelectedValue;
			// Some operations with this row
			string path = string.Format(@"{0}", test.location);
			Process.Start("explorer.exe", path);
		}

	}
}