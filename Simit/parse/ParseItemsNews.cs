using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simit.entities;

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
                    dynamic news = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    var items = news.items;
                    foreach (var item in items)
                    {
                        ItemNews itemNews = new ItemNews();
                        if (item.id.videoId != null)
                            itemNews.ID_VIDEO = item.id.videoId;
                        if (item.snippet.title != null)
                            itemNews.TITLE = item.snippet.title;
                        if (item.snippet.thumbnails.medium != null)
                            itemNews.URL_IMAGE_VIDEO = item.snippet.thumbnails.medium;
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

            /*
             * dynamic x = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
        var page = x.page;
        var total_pages = x.total_pages
        var albums = x.albums;
        foreach(var album in albums)
        { 
            var albumName = album.name;
            //access album data;
             * }

             * */
}
