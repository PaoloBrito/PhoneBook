using AppPhone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppPhone.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public List<Phone> ListPhone { get; set; }
        #endregion

        #region ViewModel
        PhoneBookViewModel phoneBookViewModel { get; set; }
        #endregion



        #region Constructor
        public MainViewModel()
        {
            instance = this;
            phoneBookViewModel = new PhoneBookViewModel();
        } 
        #endregion


        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance==null)
            {
                instance = new MainViewModel();      
            }
            return (instance);
        }
        #endregion


    }
}
