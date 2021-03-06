// Template: Base Controller (ApiControllerBase.t4) version 1.1

using System.Web.Http;

// Do not modify this file. This code was generated by RAML Web Api 2 Scaffolder

namespace iedge.exp
{
    [RoutePrefix("feedback")]
    public partial class FeedbackController : ApiController
    {


        /// <summary>
		/// Entity representing a feedback. Post a feedback
		/// </summary>
		/// <param name="json"></param>
        [HttpPost]
        [Route("")]
        public virtual IHttpActionResult PostBase(string json)
        {
            // Do not modify this code
            return  ((IFeedbackController)this).Post(json);
        }
    }
}
