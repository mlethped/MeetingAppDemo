using Application.MeetingRooms.CreateMeetingRoom;
using Application.MeetingRooms.DeleteMeetingRoom;
using Application.MeetingRooms.Queries.GetMeetingRoomDetails;
using Application.MeetingRooms.Queries.GetMeetingRoomList;
using Application.MeetingRooms.UpdateMeetingRoom;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Service.MeetingRoom
{
    public class MeetingRoomController : ApiController
    {
        private readonly ICreateMeetingRoomCommand _createCommand;
        private readonly IUpdateMeetingRoomCommand _updateCommand;
        private readonly IDeleteMeetingRoomCommand _deleteCommand;
        private readonly IGetMeetingRoomListQuery _getListQuery;
        private readonly IGetMeetingRoomDetailQuery _getDetailsQuery;

        public MeetingRoomController(
            ICreateMeetingRoomCommand createCommand,
            IUpdateMeetingRoomCommand updateCommand,
            IDeleteMeetingRoomCommand deleteCommand,
            IGetMeetingRoomListQuery getListQuery,
            IGetMeetingRoomDetailQuery getDetailsQuery)
        {
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
            _getListQuery = getListQuery;
            _getDetailsQuery = getDetailsQuery;
        }

        public (HttpResponseMessage, IEnumerable<GetMeetingRoomListModel>) Get()
        {
            IEnumerable<GetMeetingRoomListModel> result;

            try
            {
                result = _getListQuery.Execute();
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, "Error occured while getting list of meeting rooms");
                return (new HttpResponseMessage(HttpStatusCode.NotFound), null);
            }

            return (new HttpResponseMessage(HttpStatusCode.Found), result);
        }

        public (HttpResponseMessage, GetMeetingRoomDetailModel) Get(Guid id)
        {
            GetMeetingRoomDetailModel result; 

            try
            {
                result = _getDetailsQuery.Execute(id); ;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, $"Error occured while getting details for meeting room with id: {id}");
                return (new HttpResponseMessage(HttpStatusCode.NotFound), null);
            }

            return (new HttpResponseMessage(HttpStatusCode.Found), result);
        }

        public HttpResponseMessage Create(CreateMeetingRoomModel meetingRoom)
        {
            try
            {
                _createCommand.Execute(meetingRoom);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, $"Error occured while creating new meeting room: {meetingRoom}");
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        public HttpResponseMessage Update(UpdateMeetingRoomModel meetingRoom)
        {
            if(meetingRoom == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            try
            {
                _updateCommand.Execute(meetingRoom);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, $"Error occured while updating meeting room with id: {meetingRoom.Id}");
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(DeleteMeetingRoomModel meetingRoom)
        {
            if (meetingRoom == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            try
            {
                _deleteCommand.Execute(meetingRoom);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, $"Error occured while deleting meeting room with id: {meetingRoom.Id}");
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
