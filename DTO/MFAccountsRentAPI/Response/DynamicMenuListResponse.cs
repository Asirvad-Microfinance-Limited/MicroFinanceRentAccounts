using DTO.MFAccountsRentAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.MFAccountsRentAPI.Response
{
    public class DynamicMenuListResponse
    {
        public DynamicMenuListResponse()
        {
            isDataAvailable = false;
        }
        public bool isDataAvailable { get; set; }

        public List<MenuListData> menuList { get; set; }

        public string encryptedResStr { get; set; }


    }
}