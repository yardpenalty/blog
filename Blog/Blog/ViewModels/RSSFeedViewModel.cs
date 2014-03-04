//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Blog.ViewModels
//{
//    public class RSSViewModel
//    {
//        public string Title { get; set; }
//        public string Body { get; set; }
//        public string ImageUrl { get; set; }
//        public string Author { get; set; }
//        public DateTime PublishedDate { get; set; }
//        public string Url { get; set; }
//    }
//    public class NewsManager
//    {
//        public List<NewsItem> GenerateNews()
//        {
//            List<NewsItem> newsItems = new List<NewsItem>();

//            NewsItem newsItem1 = new NewsItem()
//            {
//                Author = "Mohamed Salah",
//                Body = "Clashes have broken out in several areas of Lebanon following Sunday's funeral of the senior intelligence official, Wissam al-Hassan.The most serious confrontations were in the northern city of Tripoli, where at least three people were killed as Sunni and Shia gunmen exchanged fire.In Beirut, there were clashes between soldiers and armed men in the Sunni Tariq al-Jadida district.Gen Hassan, a Sunni, was killed by a car bomb in the capital on Friday.He was the head of the intelligence branch of the Internal Security Forces and an outspoken critic of Syrian President Bashar al-Assad, a member of the Shia-based Alawite sect.",
//                Title = "Lebanon sees sectarian clashes after Hassan killing",
//                PublishedDate = DateTime.Today.AddDays(-5),
//                ImageUrl = "http://news.bbcimg.co.uk/media/images/63629000/jpg/_63629530_tripoli_reuters.jpg",
//                Url = "http://www.bbc.co.uk/news/world-middle-east-20025095"
//            };
//            newsItems.Add(newsItem1);

//            NewsItem newsItem2 = new NewsItem()
//            {
//                Author = "Mohamed Salah",
//                Body = "Cuba's revolutionary former leader Fidel Castro has written a strongly-worded article condemning persistent rumours that he is on his death bed.The 86-year-old attacked international media \"lies\", and published photos of himself in Cuba's state media.He said he was in good health, and could not even remember the last time he had a headache.Venezuelan politician Elias Jaua said on Sunday he had a five-hour meeting with Mr Castro the previous day.He presented a photo of the encounter, and said the former Cuban leader was \"very well, very lucid\".",
//                Title = "Cuba's Fidel Castro attacks 'lies' about his health",
//                PublishedDate = DateTime.Today.AddDays(-4),
//                ImageUrl = "http://news.bbcimg.co.uk/media/images/63628000/jpg/_63628162_63628161.jpg",
//                Url = "http://www.bbc.co.uk/news/world-latin-america-20025624"
//            };
//            newsItems.Add(newsItem2);

//            return newsItems;
//        }
//    }
//}