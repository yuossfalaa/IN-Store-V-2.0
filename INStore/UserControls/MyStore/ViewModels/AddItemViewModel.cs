using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
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
    public partial class AddItemViewModel : ViewModelBase
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
        public AddItemViewModel(IStoreItemsService storeItemsService, MyStoreViewModel myStoreViewModel)
        {
            _storeItemsService = storeItemsService;
            _myStoreViewModel = myStoreViewModel;
            StoreItem = new StoreItems();
 
        }
        #region Private Methods
        [RelayCommand]
        private async void AutoFill()
        {
            await Task.Run(async () =>
            {
                List<StoreItems> storeItems = await _storeItemsService.GetAll(true);
                _AutoFillstoreItem = storeItems.LastOrDefault(a => a.IsDeleted == true && a.Item.ItemBarCode == StoreItem.Item.ItemBarCode);
                if (_AutoFillstoreItem != null)
                {
                    StoreItem.Item.ItemSellingPrice= _AutoFillstoreItem.Item.ItemSellingPrice;
                    StoreItem.Item.ItemPurchasingPrice= _AutoFillstoreItem.Item.ItemPurchasingPrice;
                    StoreItem.Item.ItemName= _AutoFillstoreItem.Item.ItemName;
                    StoreItem.Item.ItemDescription= _AutoFillstoreItem.Item.ItemDescription;
                    StoreItem.Item.Image= _AutoFillstoreItem.Item.Image;
                    
                    
                    
                    OnPropertyChanged(nameof(StoreItem)); 
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
            }
            catch(Exception ex)
            {
                _myStoreViewModel._MyStoreViewModelLogger.LogError(ex.Message);

            }
        }
        [RelayCommand]
        public async Task AddStoreItem()
        {
            try
            {
                if (await TheSameBarcodeExist())
                {
                    _myStoreViewModel._SnackbarMessageQueue.Enqueue(LocalizedStrings.Instance["AddStoreItemTheSameBarcodeExist"]);
                    return;
                }
                if (StoreItem != null)
                {
                    await Task.Run(async () =>
                    {
                        if (StoreItem.Item.Image.Length == 1)
                        {
                            BitmapImage image = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/image-custom.png"));
                            StoreItem.Item.Image = ImageToByteArray(image);
                        }

                        await _storeItemsService.Create(StoreItem);
                    });

                }
                _myStoreViewModel.GetAllStoreItemsCommand.Execute(null);
                MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(null, null);
            }
            catch (Exception ex)
            {
                _myStoreViewModel._MyStoreViewModelLogger.LogError(ex.Message);
            }
        }
        private async Task<bool> TheSameBarcodeExist()
        {
            List<StoreItems> HavethesameBarcode = await _storeItemsService.Get(StoreItem.Item.ItemBarCode);
            if (HavethesameBarcode.Where(a => a.Item.ItemBarCode == StoreItem.Item.ItemBarCode).Count() >= 1)
            {
                return true;
            }
            return false;
        }
        private byte[] ImageToByteArray(BitmapImage imageIn)
        {
            try
            {
                byte[] data;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(imageIn));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();
                }
                return data;
            }
            catch (Exception ex)
            {
                _myStoreViewModel._MyStoreViewModelLogger.LogError(ex.Message);
                return null;

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
            catch (Exception ex)
            {
                _myStoreViewModel._MyStoreViewModelLogger.LogError(ex.Message);
                return null;

            }
        }
        #endregion


    }
}
