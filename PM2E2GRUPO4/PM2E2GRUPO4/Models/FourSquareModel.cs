using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E2GRUPO4.Clase
{
    public class FourSquareModel
    {
        public class Meta
        {
            public int code { get; set; }
            public string requestId { get; set; }
        }

        public class Item
        {
            public int unreadCount { get; set; }
        }

        public class Notification
        {
            public string type { get; set; }
            public Item item { get; set; }
        }

        public class Params
        {
            public string ll { get; set; }
            public string radius { get; set; }
        }

        public class Target
        {
            public string type { get; set; }
            public string url { get; set; }
            public Params @params { get; set; }
        }

        public class Refinement
        {
            public string query { get; set; }
        }

        public class QueryRefinements
        {
            public Target target { get; set; }
            public List<Refinement> refinements { get; set; }
        }

        public class Warning
        {
            public string text { get; set; }
        }

        public class Ne
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Sw
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class SuggestedBounds
        {
            public Ne ne { get; set; }
            public Sw sw { get; set; }
        }

        public class Item3
        {
            public string summary { get; set; }
            public string pluralSummary { get; set; }
            public string type { get; set; }
            public string reasonName { get; set; }
            public Detail detail { get; set; }
            public Reasons reasons { get; set; }
            public Snippets snippets { get; set; }
            public Venue venue { get; set; }
            public Photo photo { get; set; }
            public List<Tip> tips { get; set; }
            public string referralId { get; set; }
        }

        public class Reasons
        {
            public int count { get; set; }
            public List<Item> items { get; set; }
        }

        public class Likes
        {
            public int count { get; set; }
            public List<object> groups { get; set; }
            public string summary { get; set; }
        }

        public class Todo
        {
            public int count { get; set; }
        }

        public class Photo
        {
            public string prefix { get; set; }
            public string suffix { get; set; }
            public string id { get; set; }
            public int createdAt { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string visibility { get; set; }
        }

        public class User
        {
            public string id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string gender { get; set; }
            public string countryCode { get; set; }
            public string canonicalUrl { get; set; }
            public string canonicalPath { get; set; }
            public Photo photo { get; set; }
            public bool isAnonymous { get; set; }
        }

        public class Object
        {
            public string id { get; set; }
            public int createdAt { get; set; }
            public string text { get; set; }
            public string type { get; set; }
            public string canonicalUrl { get; set; }
            public string canonicalPath { get; set; }
            public Likes likes { get; set; }
            public bool logView { get; set; }
            public int agreeCount { get; set; }
            public int disagreeCount { get; set; }
            public Todo todo { get; set; }
            public User user { get; set; }
        }

        public class Detail
        {
            public string type { get; set; }
            public Object @object { get; set; }
        }

        public class Snippets
        {
            public int count { get; set; }
            public List<Item> items { get; set; }
        }

        public class Contact
        {
            public string twitter { get; set; }
        }

        public class LabeledLatLng
        {
            public string label { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Location
        {
            public string address { get; set; }
            public string crossStreet { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }
            public List<LabeledLatLng> labeledLatLngs { get; set; }
            public int distance { get; set; }
            public string cc { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string contextLine { get; set; }
            public long contextGeoId { get; set; }
            public List<string> formattedAddress { get; set; }
        }

        public class Icon
        {
            public string prefix { get; set; }
            public string mapPrefix { get; set; }
            public string suffix { get; set; }
        }

        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
            public string pluralName { get; set; }
            public string shortName { get; set; }
            public Icon icon { get; set; }
            public bool primary { get; set; }
        }

        public class Stats
        {
            public int tipCount { get; set; }
            public int usersCount { get; set; }
            public int checkinsCount { get; set; }
        }

        public class Price
        {
            public int tier { get; set; }
            public string message { get; set; }
            public string currency { get; set; }
        }

        public class BeenHere
        {
            public int count { get; set; }
            public bool marked { get; set; }
            public int lastCheckinExpiredAt { get; set; }
        }

        public class Photos
        {
            public int count { get; set; }
            public List<object> groups { get; set; }
        }

        public class HereNow
        {
            public int count { get; set; }
            public string summary { get; set; }
            public List<object> groups { get; set; }
        }

        public class Venue
        {
            public string id { get; set; }
            public string name { get; set; }
            
        }

        public class Tip
        {
            public string id { get; set; }
            public int createdAt { get; set; }
            public string text { get; set; }
            public string type { get; set; }
            public string canonicalUrl { get; set; }
            public string canonicalPath { get; set; }
            public Likes likes { get; set; }
            public bool logView { get; set; }
            public int agreeCount { get; set; }
            public int disagreeCount { get; set; }
            public Todo todo { get; set; }
            public User user { get; set; }
        }

        public class Group
        {
            public string type { get; set; }
            public string name { get; set; }
            public List<Item> items { get; set; }
        }

        public class Response
        {
            public QueryRefinements queryRefinements { get; set; }
            public Warning warning { get; set; }
            public int suggestedRadius { get; set; }
            public string headerLocation { get; set; }
            public string headerFullLocation { get; set; }
            public string headerLocationGranularity { get; set; }
            public int totalResults { get; set; }
            public SuggestedBounds suggestedBounds { get; set; }
            public List<Group> groups { get; set; }
        }

        public class Root
        {
            public Meta meta { get; set; }
            public List<Notification> notifications { get; set; }
            public Response response { get; set; }
        }
    }
}
