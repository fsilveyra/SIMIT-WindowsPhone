using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simit.entities;
using System.Runtime.Serialization;
using Simit.classAux;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Simit.parse
{
    public class ParseItemsNews
    {
        List<ItemNews> listItemNews = null;

        public List<ItemNews> parseJsonItemNews(String json)
        {
            if(json != null)
            {
                try
                {
                    listItemNews = new List<ItemNews>();
                    JObject news = JObject.Parse(json);
                    IList<JToken> items = news["items"].Children().ToList();
                    foreach (JToken item in items)
                    {
                        ItemNews itemNews = JsonConvert.DeserializeObject<ItemNews>(item.ToString());
                        listItemNews.Add(itemNews);
                    }
                }
                catch (Exception)
                {
                    return listItemNews;
                }
            }
            return listItemNews;
        }
    }
}
