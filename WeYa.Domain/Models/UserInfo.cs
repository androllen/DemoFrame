/********************************************************************************
** 作者： androllen
** 日期： 16/4/15 19:05:06
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Newtonsoft.Json;

namespace WeYa.Domain.Models
{
    public class UserInfo : LoginResult
    {
        private int id = 0;

        [JsonProperty("id")]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyOfPropertyChange(nameof(Id));
            }
        }
    }
}
