using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace FlightDocsSystem.Services
{
    public class GroupService : IGroupService
    {
        private readonly FlightDocsSystemContext _context;

        public GroupService(FlightDocsSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Group>> getAllGroupAsync()
        {
            var Groups = await _context.Groups.ToListAsync();
            return Groups;
        }

        public async Task<Group> getGroupAsync(int id)
        {
            var Group = await _context.Groups.FindAsync(id);
            if (_context.Groups == null || Group == null)
            {
                throw new NotFoundException("GroupID does not exist");
            }
            return Group;
        }

        public async Task<GroupConditionDTO> GetGroupByConditionAsync(int groupID)
        {
            var group = await _context.Groups
                .Include(g => g.users)
                .Where(g => g.GroupID == groupID)
                .FirstOrDefaultAsync();

            if (group == null)
            {
                throw new NotFoundException("GroupID does not exist");
            }

            var groupConditionDTO = new GroupConditionDTO
            {
                GroupName = group.GroupName,
                Members = group.users.Count,
                CreateDate = group.CreateDate,
                Note = group.Note,
                Creator = group.Email
            };
            return groupConditionDTO;
        }

        public async Task<Group> AddGroupAsync(GroupDTO GroupDTO)
        {
            if (GroupDTO == null)
            {
                throw new NotFoundException("Please enter complete information");
            }
            var NewGroup = new Group
            {
                GroupName = GroupDTO.GroupName,
                Note = GroupDTO.Note,
                CreateDate = DateTime.Now,
                PermissionID = GroupDTO.PermissionID
            };
            _context.Groups.Add(NewGroup);
            await _context.SaveChangesAsync();
            return NewGroup;
        }

        public async Task<Group> UpdateGroupAsync(int id, GroupDTO model)
        {
            var existingGroup = await _context.Groups.FindAsync(id);
            if (existingGroup == null)
            {
                throw new NotFoundException("ID does not exist");
            }
            else
            {
                existingGroup.GroupName = model.GroupName;
                existingGroup.Note = model.Note;
                existingGroup.UpdateDate = DateTime.Now;
                existingGroup.PermissionID = model.PermissionID;
                _context.Groups.Update(existingGroup);
                await _context.SaveChangesAsync();  
            }
            return existingGroup;
        }

        public async Task DeleteGroupAsync(int id)
        {
            var existingGroup = _context.Groups!.SingleOrDefault(b => b.GroupID == id);
            if (existingGroup != null)
            {
                _context.Groups.Remove(existingGroup);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("ID does not exist");
            }
        }
    }
}
