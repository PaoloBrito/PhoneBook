using AppPhone.Models;
using AppPhone.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AppPhone.ViewModels
{
    public class PhoneBookViewModel: BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        ObservableCollection<Phone> phones;
        #endregion

        #region Properties

        ObservableCollection<Phone> Phones
        {
            get { return this.phones; }
            set { SetValue(ref this.phones, value);}

        }
        #endregion

        #region Constructor
        public PhoneBookViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPhone();
        }
        #endregion

        #region Methods
        private async void LoadPhone()
        {
            var connection = await apiService.CheckConnection();
            if(!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Internet Error Connection", connection.Message,"Accept");
                return;
            }
            var response = await apiService.GetList<Phone>(
                "http://localhost:50310/",
                "api/",
                "Phones"
                );

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error Phone Service",
                    response.Message,
                    "Accept"
                    );
                return;
            }
            MainViewModel main = MainViewModel.GetInstance();
            main.ListPhone = (List<Phone>) response.Result;

            this.Phones = new ObservableCollection<Phone>(ToPhoneCollect());
        }

        private IEnumerable<Phone> ToPhoneCollect()
        {
            ObservableCollection<Phone> collection = new ObservableCollection<Phone>();
            MainViewModel main = MainViewModel.GetInstance();
            foreach (var lista in main.ListPhone)
            {
                Phone phone = new Phone();
                phone.PhoneID = lista.PhoneID;
                phone.Name = lista.Name;
                phone.Type = lista.Type;
                phone.Contact = lista.Contact;
                collection.Add(phone);
            }
            return (collection);
        }
        #endregion


    }
}