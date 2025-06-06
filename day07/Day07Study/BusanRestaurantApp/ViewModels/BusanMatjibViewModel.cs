﻿using BusanRestaurantApp.Helpers;
using BusanRestaurantApp.Models;
using CefSharp.DevTools.Network;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.Controls.Dialogs;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BusanRestaurantApp.ViewModels
{
    public partial class BusanMatjibViewModel : ObservableObject
    {
        IDialogCoordinator dialogCoordinator;

        public BusanMatjibViewModel(IDialogCoordinator coordinator)
        {
            this.dialogCoordinator = coordinator;

            PageNo = 1; NumOfRows = 10;

            GetDataFromOpenApi();
        }

        private ObservableCollection<BusanItem> _busanItems;

        public ObservableCollection<BusanItem> BusanItems { 
            get => _busanItems;
            set => SetProperty(ref _busanItems, value);
        }

        private int _pageNo;
        public int PageNo
        {
            get => _pageNo;
            set => SetProperty(ref _pageNo, value);
        }

        private int _numOfRows;

        public int NumOfRows { 
            get => _numOfRows;
            set => SetProperty(ref _numOfRows, value);
        }

        [RelayCommand]
        private async Task GetDataFromOpenApi()
        {
            string baseUri = "http://apis.data.go.kr/6260000/FoodService/getFoodKr";
            string myServiceKey = "JzmUY2JqiPqaZHmZ7VDke8wMFu3m%2FCXZSUCawmglK99g1cw5ytYYWZ%2F4VmiJz2Wn5MB1aBEA7N0YlXlJz%2B%2FK8A%3D%3D&pageNo=1&numOfRows=10&resultType=json";

            StringBuilder strUri = new StringBuilder();
            strUri.Append($"serviceKey={myServiceKey}&");
            strUri.Append($"pageNo={PageNo}&");
            strUri.Append($"numOfRows={NumOfRows}&");
            strUri.Append($"resultType=json");
            string totalOpenApi = $"{baseUri}?{strUri}";
            Common.LOGGER.Info(totalOpenApi);

            HttpClient client = new HttpClient();
            ObservableCollection<BusanItem> busanItems = new ObservableCollection<BusanItem>();

            try
            {
                var response = await client.GetStringAsync(totalOpenApi);
                //Common.LOGGER.Info(response);

                // Newtonsoft.Json으로 Json처리방식
                var jsonResult = JObject.Parse(response);
                var message = jsonResult["getFoodKr"]["header"]["message"];
                var status = Convert.ToString(jsonResult["getFoodKr"]["header"]["code"]); // 00이면 성공

                if(status == "00")
                {
                    var item = jsonResult["getFoodKr"]["item"];
                    var jsonArray = item as JArray;

                    foreach(var subitem in jsonArray)
                    {
                        busanItems.Add(new BusanItem
                        {
                            Uc_Seq = Convert.ToInt32(subitem["UC_SEQ"]),
                            Main_Title = Convert.ToString(subitem["MAIN_TITLE"]),
                            Gugun_Nm = Convert.ToString(subitem["GUGUN_NM"]),
                            Lat = Convert.ToDouble(subitem["LAT"]),
                            Lng = Convert.ToDouble(subitem["LNG"]),
                            Place = Convert.ToString(subitem["PLACE"]),
                            Title = Convert.ToString(subitem["TITLE"]),
                            SubTitle = Convert.ToString(subitem["SUBTITLE"]),
                            Addr1 = Convert.ToString(subitem["ADDR1"]),
                            Addr2 = Convert.ToString(subitem["ADDR2"]),
                            Cntct_Tel = Convert.ToString(subitem["CNTCT_TEL"]),
                            Homepage_Url = Convert.ToString(subitem["HOMEPAGE_URL"]),
                            Usage_Day_Week_And_Time = Convert.ToString(subitem["USAGE_DAY_WEEK_AND_TIME"]),
                            Rprsntv_Menu = Convert.ToString(subitem["RPRSNTV_MENU"]),
                            Main_Img_Normal = Convert.ToString(subitem["MAIN_IMG_NORMAL"]),
                            Main_Img_Thumb = Convert.ToString(subitem["MAIN_IMG_THUMB"]),
                            ItemCntnts = Convert.ToString(subitem["ITEMCNTNTS"]),
                        });
                    }
                    BusanItems = busanItems;
                    Common.LOGGER.Info("OpenAPI 데이터 로드 완료!");
                }
            }
            catch(Exception ex)
            {
                await this.dialogCoordinator.ShowMessageAsync(this, "예외", ex.Message);
                Common.LOGGER.Fatal(ex.Message);
            }
        }
    }
}
