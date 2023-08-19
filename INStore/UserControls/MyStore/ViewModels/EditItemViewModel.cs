using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.Language;
using INStore.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;

namespace INStore.UserControls.MyStore.ViewModels
{
    public partial class EditItemViewModel : ViewModelBase
    {
        #region Private Vars
        private readonly IStoreItemsService _storeItemsService;
        private readonly MyStoreViewModel _myStoreViewModel;
        private StoreItems _AutoFillstoreItem;

        #endregion
        #region Public Vars
        [ObservableProperty]
        StoreItems storeItem;
        #endregion
        public EditItemViewModel(IStoreItemsService storeItemsService, MyStoreViewModel myStoreViewModel, StoreItems items)
        {
            _storeItemsService = storeItemsService;
            _myStoreViewModel = myStoreViewModel;
            StoreItem = new StoreItems();
            StoreItem = items;

         }
        #region Private Methods
        [RelayCommand]
        private async void AutoFill()
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
        [RelayCommand]
        private void AddImageToStoreItem()
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
                        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            using (System.Drawing.Image original = System.Drawing.Image.FromStream(fs))
                            {
                                StoreItem.Item.Image = ImageToByteArray(original);
                            }
                        }
                    }
                }
                _myStoreViewModel._MyStoreViewModelLogger.Log(LogLevel.Information, "Image Added");
            }
            catch (Exception ex)
            {
                _myStoreViewModel._MyStoreViewModelLogger.LogError(ex.Message);
            }
        }
        [RelayCommand]
        public async Task EditStoreItem()
        {

            if (await TheSameBarcodeExist())
            {
                _myStoreViewModel._SnackbarMessageQueue.Enqueue(LocalizedStrings.Instance["AddStoreItemTheSameBarcodeExist"]);
                return;
            }

            try
            {
                await Task.Run(async () =>
                {
                    await _storeItemsService.Update(StoreItem.Id, StoreItem);
                    _myStoreViewModel.GetAllStoreItemsCommand.Execute(null);
                });

                MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(null, null);

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
        private async Task<bool> TheSameBarcodeExist()
        {
            List<StoreItems> HavethesameBarcode = await _storeItemsService.Get(StoreItem.Item.ItemBarCode);
            if (HavethesameBarcode.Where(a => a.Id != StoreItem.Id && a.Item.ItemBarCode == StoreItem.Item.ItemBarCode).Count() >= 1)
            {
                return true;
            }
            return false;
        }

        #endregion





    }
}
