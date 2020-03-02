﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FocusOnXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EmptyViewTemplateGallery : ContentPage
	{
		readonly DemoFilteredItemSource _demoFilteredItemSource = new DemoFilteredItemSource();
		readonly EmptyViewGalleryFilterInfo _emptyViewGalleryFilterInfo = new EmptyViewGalleryFilterInfo();

		public EmptyViewTemplateGallery ()
		{
			InitializeComponent ();

			CollectionView.ItemTemplate = ExampleTemplates.PhotoTemplate();

			CollectionView.ItemsSource = _demoFilteredItemSource.Items;
			CollectionView.EmptyView = _emptyViewGalleryFilterInfo;

			SearchBar.SearchCommand = new Command(() =>
			{
				_demoFilteredItemSource.FilterItems(SearchBar.Text);
				_emptyViewGalleryFilterInfo.Filter = SearchBar.Text;
			});
		}
	}
}