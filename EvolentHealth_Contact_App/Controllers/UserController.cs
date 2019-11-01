using System;
using System.Web.Http;
using EvolentHealth_Contact_App.BL;
using EvolentHealth_Contact_App.Entities;
using EvolentHealth_Contact_App.Filters;
using EvolentHealth_Contact_App.Utilities;

namespace EvolentHealth_Contact_App.Controllers
{
    [BasicAuthorization]
    public class UserController : ApiController
    {

        private readonly IContactService _contactService;
        private readonly ILogManager _logManager;
        public UserController(IContactService contactService, ILogManager logManager)
        {
            _contactService = contactService;
            _logManager = logManager;
        }

        /// <summary>
        /// Gets all the users
        /// </summary>
        /// <returns>List of Users</returns>
        /// <response code="200">returns all users</response>
        /// <response code="404">If the list is empty</response>
        /// <response code="500">In case of any exception</response>
        [Route("api/user/all")]
        public IHttpActionResult GetAllUsers()
        {
            try
            {
                _logManager.LogInfo("GetAllUser- start");
                var users = _contactService.GetUsers();
                _logManager.LogInfo("GetAllUser- end");
                if (users?.Count > 0)
                    return Ok(users);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logManager.LogError($"GetAllUsers - Error while processing request : Message : {ex.Message} |strack trace: {ex.StackTrace}");
                return InternalServerError();
            }
        }

        /// <summary>
        /// Get the user details by id
        /// </summary>
        /// <param name="id">id of the user</param>
        /// <returns>User details</returns>
        /// <response code="200">User details</response>
        /// <response code="404">If user is not found</response>
        /// <response code="500">In case of any exception</response>
        [Route("api/user/{id}",Name = "GetUser")]
        public IHttpActionResult GetUser(int id)
        {
            try
            {
                _logManager.LogInfo("GetUser- start");
                var user = _contactService.GetUser(id);
                _logManager.LogInfo("GetUser- end");
                if (user != null)
                    return Ok(user);
                else
                    return NotFound();

            }
            catch (Exception ex)
            {
                _logManager.LogError($"GetUser - Error while processing request : Message : {ex.Message} |strack trace: {ex.StackTrace}");
                return InternalServerError();
            }
        }

        /// <summary>
        /// Saves the user details
        /// </summary>
        /// <param name="user">User details object</param>
        /// <returns>200 - saved successfully</returns>
        /// <response code="200">User saved successfully</response>
        /// <response code="400">User details validation failed</response>
        /// <response code="500">In case of any exception</response>
        [Route("api/user")]
        [HttpPost]
        public IHttpActionResult AddUser([FromBody]User user)
        {
            try
            {
                _logManager.LogInfo("AddUser- start");

                if (user==null || !ModelState.IsValid)
                {
                    _logManager.LogWarn("AddUser- Bad request. ModelState invalid");
                    return BadRequest(ModelState);
                }

                var result = _contactService.AddUser(user);

                _logManager.LogInfo("AddUser- end");

                if (result)
                    return CreatedAtRoute("GetUser", new { id = user.UserId }, user);
                else
                    return InternalServerError();
            }
            catch (Exception ex)
            {
                _logManager.LogError($"AddUser - Error while processing request : Message : {ex.Message} |strack trace: {ex.StackTrace}");
                return InternalServerError();
            }
        }

        /// <summary>
        /// Updates the user details
        /// </summary>
        /// <param name="user">User details object</param>
        /// <returns>User updated successfully</returns>
        /// <response code="200">User saved successfully</response>
        /// <response code="400">User details validation failed</response>
        /// <response code="500">In case of any exception</response>
        [HttpPut]
        [Route("api/user")]
        public IHttpActionResult UpdateUser(User user)
        {
            try
            {
                _logManager.LogInfo("UpdateUser- start");

                if (user==null || !ModelState.IsValid)
                {
                    _logManager.LogWarn("UpdateUser- Bad request. ModelState invalid");
                    return BadRequest(ModelState);
                }

                var result = _contactService.UpdateUser(user);
                _logManager.LogInfo("UpdateUser- end");
                if (result)
                    return Ok("User updated successfully");
                else
                    return InternalServerError();
            }
            catch (Exception ex)
            {
                _logManager.LogError($"UpdateUser - Error while processing request : Message : {ex.Message} |strack trace: {ex.StackTrace}");
                return InternalServerError();
            }

        }

        /// <summary>
        /// Inactivate the user
        /// </summary>
        /// <param name="id">id of the user to be inactivated</param>
        /// <returns>User inactivated successfully</returns>
        /// <response code="200">User inactivated successfully</response>
        /// <response code="500">In case of any exception</response>
        [HttpPost]
        [Route("api/user/inactivate")]
        public IHttpActionResult InactivateUser(int id)
        {
            try
            {
                _logManager.LogInfo("InactivateUser- start");

                var result = _contactService.InactivateUser(id);

                _logManager.LogInfo("InactivateUser- end");
                if (result)
                    return Ok("User Inactivated");
                else
                    return InternalServerError();
            }
            catch (Exception ex)
            {
                _logManager.LogError($"InactivateUser - Error while processing request : Message : {ex.Message} |strack trace: {ex.StackTrace}");
                return InternalServerError();
            }


        }

    }
}