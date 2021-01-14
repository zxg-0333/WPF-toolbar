using GBCourtApp.Models;
using GBCourtApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBCourtApp.Controller
{
    public class VMController
    {
        public static MainVM CreateVM()
        {
            MainVM result =  new MainVM();
            result.ToolBarItems = new System.Collections.ObjectModel.ObservableCollection<Models.ToolBarItemModel> {
                new ToolBarItemModel {  ID="11", Name = "用户登录",ImagePath = "/Images/登录系统.png"},
                new ToolBarItemModel {  ID="21", Name = "用户注销",ImagePath = "/Images/注销系统.png"},
                new ToolBarItemModel {  ID="22", Name = "开始合议",ImagePath = "/Images/开始庭审.png"},
                new ToolBarItemModel {  ID="23", Name = "停止合议",ImagePath = "/Images/结束庭审.png"},
                new ToolBarItemModel {  ID="24", Name = "案件信息",ImagePath = "/Images/案件信息.png"}
            };
            return result;
        }
    }
}
