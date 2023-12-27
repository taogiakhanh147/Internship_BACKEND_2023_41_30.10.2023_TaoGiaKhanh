using FlightDocsSystem.DTO;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.IServices
{
    public interface IGroupService
    {
        public Task<List<Group>> getAllGroupAsync();

        public Task<Group> getGroupAsync(int id);

        public Task<GroupConditionDTO> GetGroupByConditionAsync(int groupID);

        public Task<Group> AddGroupAsync(GroupDTO model);

        public Task<Group> UpdateGroupAsync(int id, GroupDTO model);

        public Task DeleteGroupAsync(int id);
    }
}
