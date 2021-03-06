﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace iedge.exp
{
        public class Eventfeedback
        {
            [JsonProperty("eventid")]
            public string eventid { get; set; }
            [JsonProperty("feedbackval")]
            public string feedbackval { get; set; }
            [JsonProperty("email")]
            public string email { get; set; }
            [JsonProperty("phone")]
            public string phone { get; set; }
            [JsonProperty("fullname")]
            public string fullname { get; set; }
        }

        public class Feedback
        {
            [JsonProperty("elementid")]
            public string elementid { get; set; }
            [JsonProperty("eventid")]
            public string eventid { get; set; }
            [JsonProperty("metricid")]
            public string metricid { get; set; }
            [JsonProperty("feedbackval")]
            public string feedbackval { get; set; }
            [JsonProperty("smileytype")]
            public string smileytype { get; set; }
            [JsonProperty("smileyid")]
            public string smileyid { get; set; }
        }

        public class MainFeedBack
        {
            [JsonProperty("eventfeedback")]
            public Eventfeedback eventfeedback { get; set; }
            [JsonProperty("feedbacks")]
            public IList<Feedback> feedbacks { get; set; }
        }

        public class Smiley
        {
            [JsonProperty("id")]
            public string id { get; set; }

            [JsonProperty("label")]
            public string label { get; set; }

            [JsonProperty("image")]
            public string image { get; set; }

            [JsonProperty("type")]
            public string type { get; set; }
        }

        public class Settings
        {
            [JsonProperty("id")]
            public string id { get; set; }

            [JsonProperty("title")]
            public string title { get; set; }

            [JsonProperty("smilies")]
            public IList<Smiley> smilies { get; set; }
        }

        public class Element
        {
            [JsonProperty("id")]
            public string id { get; set; }

            [JsonProperty("title")]
            public string title { get; set; }

            [JsonProperty("icon")]
            public string icon { get; set; }

            [JsonProperty("note")]
            public string note { get; set; }
        }

        public class Metric
        {
            [JsonProperty("id")]
            public string id { get; set; }

            [JsonProperty("label")]
            public string label { get; set; }

            [JsonProperty("icon")]
            public string icon { get; set; }

            [JsonProperty("elements")]
            public IList<Element> elements { get; set; }
        }

        public class Event
        {
            [JsonProperty("settings")]
            public Settings settings { get; set; }
            [JsonProperty("metrics")]
            public IList<Metric> metrics { get; set; }
        }
    }
