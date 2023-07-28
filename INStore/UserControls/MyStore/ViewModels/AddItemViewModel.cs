﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    public class AddItemViewModel : ViewModelBase
    {
        #region Private Vars
        private readonly IStoreItemsService _storeItemsService;
        private readonly MyStoreViewModel _myStoreViewModel;

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
        public ICommand AddStoreItemCommand { get; set; }

        #endregion
        public AddItemViewModel(IStoreItemsService storeItemsService, MyStoreViewModel myStoreViewModel)
        {
            _storeItemsService = storeItemsService;
            _myStoreViewModel = myStoreViewModel;
            StoreItem = new StoreItems();
            AddImageToStoreItemCommand = new RelayCommand(AddImageToStoreItemFunc);
            AddStoreItemCommand = new AddStoreItem(_storeItemsService, _myStoreViewModel, this);

        }
        #region Private Methods
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
            }
            catch(Exception ex)
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
            catch (Exception ex)
            {
                _myStoreViewModel._MyStoreViewModelLogger.LogError(ex.Message);
                return null;

            }
        }
        #endregion


    }
}
