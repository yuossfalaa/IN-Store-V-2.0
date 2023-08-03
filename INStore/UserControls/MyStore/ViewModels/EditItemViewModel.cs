using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.UserControls.MyStore.Commands;
using INStore.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;

namespace INStore.UserControls.MyStore.ViewModels
{
    public class EditItemViewModel : ViewModelBase
    {
        #region Private Vars
        private readonly IStoreItemsService _storeItemsService;
        private readonly MyStoreViewModel _myStoreViewModel;
        private StoreItems _AutoFillstoreItem;

        #endregion
        #region Public Vars

        private StoreItems _StoreItem;

        public StoreItems StoreItem
        {
            get { return _StoreItem; }
            set { _StoreItem = value; OnPropertyChanged(nameof(StoreItem)); }
        }
        #endregion
        #region Commands
        public ICommand AddImageToStoreItemCommand { get; set; }
        public ICommand EditStoreItemCommand { get; set; }
        public ICommand AutoFillCommand { get; set; }

        #endregion

        public EditItemViewModel(IStoreItemsService storeItemsService, MyStoreViewModel myStoreViewModel, StoreItems items)
        {
            _storeItemsService = storeItemsService;
            _myStoreViewModel = myStoreViewModel;
            StoreItem = new StoreItems();
            StoreItem = items;
            AddImageToStoreItemCommand = new RelayCommand(AddImageToStoreItemFunc);
            AutoFillCommand = new RelayCommand(AutoFillFunc);
            EditStoreItemCommand = new EditStoreItem(_storeItemsService, _myStoreViewModel, this);
        }
        #region Private Methods
        private async void AutoFillFunc()
        {
            await Task.Run(async () =>
            {
                List<StoreItems> storeItems = await _storeItemsService.GetAll(true);
                _AutoFillstoreItem = null;
                _AutoFillstoreItem = storeItems.LastOrDefault(a => a.IsDeleted == true && a.Item.ItemBarCode == StoreItem.Item.ItemBarCode);
                if (_AutoFillstoreItem != null)
                {
                    StoreItem.Item.ItemSellingPrice = _AutoFillstoreItem.Item.ItemSellingPrice;
                    StoreItem.Item.ItemPurchasingPrice = _AutoFillstoreItem.Item.ItemPurchasingPrice;
                    StoreItem.Item.ItemName = _AutoFillstoreItem.Item.ItemName;
                    StoreItem.Item.ItemDescription = _AutoFillstoreItem.Item.ItemDescription;
                    StoreItem.Item.Image = _AutoFillstoreItem.Item.Image;

                    OnPropertyChanged(nameof(StoreItem));
                    OnPropertyChanged(nameof(StoreItem.Item));
                }
            });

        }

        private void AddImageToStoreItemFunc()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
                if (dialog.ShowDialog() == true)
                {
                    var filePath = dialog.FileName;
                    if (filePath != null)
                    {
                        System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);
                        StoreItem.Item.Image = ImageToByteArray(image);
                    }
                }
                _myStoreViewModel._MyStoreViewModelLogger.Log(LogLevel.Information, "Image Added");
            }
            catch (Exception ex)
            {
                _myStoreViewModel._MyStoreViewModelLogger.LogError(ex.Message);
            }
        }
        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    imageIn.Save(ms, imageIn.RawFormat);
                    return ms.ToArray();
                }
            }
            catch (Exception ex) {
                _myStoreViewModel._MyStoreViewModelLogger.LogError(ex.Message);
                return null;

            }
        }
       
        #endregion





    }
}
