using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DocumentFormat.OpenXml.Presentation;
using INStore.Commands;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.UserControls.MyStore.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using SharpCompress.Common;

namespace INStore.UserControls.MyStore.Commands
{
    public class AddStoreItem : AsyncCommandBase
    {
        private readonly IStoreItemsService _storeItemsService;
        private readonly MyStoreViewModel _myStoreViewModel;
        private readonly AddItemViewModel _AddItemViewModel;

        public AddStoreItem(IStoreItemsService storeItemsService, MyStoreViewModel myStoreViewModel, AddItemViewModel addItemViewModel)
        {
            _storeItemsService = storeItemsService;
            _myStoreViewModel = myStoreViewModel;
            _AddItemViewModel = addItemViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                if (_AddItemViewModel.StoreItem !=null )
                {
                    if (_AddItemViewModel.StoreItem.Item.Image.Length == 1)
                    {
                        BitmapImage image = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/image-custom.png"));
                        _AddItemViewModel.StoreItem.Item.Image = ImageToByteArray(image);
                    }
                    
                    await _storeItemsService.Create(_AddItemViewModel.StoreItem);
                }
                _myStoreViewModel.GetAllStoreItemsCommand.Execute(null);
                MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(null,null);
            }
            catch (Exception ex)
            {
                _myStoreViewModel._MyStoreViewModelLogger.LogError(ex.Message);
            }
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

    }
}
