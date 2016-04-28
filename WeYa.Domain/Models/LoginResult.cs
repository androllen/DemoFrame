/********************************************************************************
** 作者： androllen
** 日期： 16/4/15 17:46:59
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeYa.Domain.Models
{
    public class LoginResult:BaseModel
    {
        private string name = "未登录";
        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
        }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

    }
}
