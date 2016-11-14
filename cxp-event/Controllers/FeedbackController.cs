// Template: Controller Implementation (ApiControllerImplementation.t4) version 1.1

using System.Web.Http;


namespace iedge.exp
{
    public partial class FeedbackController : IFeedbackController
    {

		/// <summary>
		/// Entity representing a feedback. Post a feedback
		/// </summary>
		/// <param name="json"></param>
        public IHttpActionResult Post(string json)
        {
            // TODO: implement Post - route: feedback/
			return Ok();
        }

    }
}
