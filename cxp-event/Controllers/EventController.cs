// Template: Controller Implementation (ApiControllerImplementation.t4) version 1.1

using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using exp;


namespace iedge.exp
{
    public partial class EventController : IEventController
    {
        // validate event information matches deviceId
        CustomerFeedbackDBEntities db = new CustomerFeedbackDBEntities();

		/// <summary>
		/// Entity representing a event. Get event configuration.
		/// </summary>
        public IHttpActionResult Get()
        {
            // TODO: implement Get - route: event/
		    var request = Request;
		    var headers = request.Headers;
            //get deviceId
		    string deviceId = (headers.Contains("deviceId")) ? headers.GetValues("deviceId").First() : "";
            //string eventId = (headers.Contains("eventId")) ? headers.GetValues("eventId").First() : "";
            //&& !string.IsNullOrEmpty(eventId)
            //is device id and event id values available
		    if (!string.IsNullOrEmpty(deviceId) )
		    {
               
		        var deviceInfo = db.DeviceTbls.FirstOrDefault(dtbl => dtbl.DeviceID == deviceId);
		        if (deviceInfo != null)
		        {
		            var m_event = new exp.Event();
		            var available = db.EventDevices.FirstOrDefault(ed => ed.DeviceID == deviceInfo.ID);
		            if (available!=null)
		            {
                        //get event info 
		                var c_event = db.Events.FirstOrDefault(e => e.ID == available.EventID);

		                m_event.settings.id = c_event.ID.ToString();
                        m_event.settings.title = c_event.Title;
                        //event smilies
                        m_event.settings.smilies = Smilies((int)available.EventID);
                        //event metiric info (including elements)
		                var metricList = MetricInfo((int)available.EventID);
		                m_event.metrics = metricList;
		            }
                    string result = Newtonsoft.Json.JsonConvert.SerializeObject(m_event);
		            return Ok(result);
		        }

                return BadRequest();


		    }

            return BadRequest();
			//return Ok();
        }

        private IList<Metric> MetricInfo(int eventId)
        {
            //get all metrics for event
            IList<Metric> metricList = new List<Metric>();
            var metrics = db.EventMetrics.Where(ev => ev.EventID == eventId);
            foreach (var metric in metrics)
            {
                var realmetric = new Metric
                {
                    icon = metric.Icon,
                    id = metric.ID.ToString(),
                    label = metric.Label
                };

                var elements = db.MetricElements.Where(m => m.EventMetricID == metric.ID);

                //get event element for metric
                if (elements.Any())
                {
                    foreach (var element in elements)
                    {
                        var realelement = new Element
                        {
                            icon = element.Icon,
                            id = element.ID.ToString(),
                            note = element.Note,
                            title = element.Title
                        };
                        realmetric.elements.Add(realelement);
                    }
                }

                metricList.Add(realmetric);
            }
            return metricList;
        }

        private IList<Smiley> Smilies(int eventId)
        {
            IList<Smiley> smilies = new List<Smiley>();
            var smiles = db.EventSmileys.Where(ev => ev.EventId == eventId);
            if (smiles.Any())
            {
                foreach (var smily in smiles)
                {
                    smilies.Add(new Smiley
                    {
                        id = smily.ID.ToString(),
                        image = smily.ImageName,
                        label = smily.Label,
                        type = smily.Type
                    });
                }
            }
           return smilies;
        }

    }
}
