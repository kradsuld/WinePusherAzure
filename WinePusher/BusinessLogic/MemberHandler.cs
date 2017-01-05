using System.Collections.Generic;
using System.Linq;
using WinePusher.Models;

namespace WinePusher.BusinessLogic
{
    class MemberHandler
    {
        WinePusherDBEntities wpe = new WinePusherDBEntities();

        public MemberHandler()
        {
        }

        public List<MemberListItem> ListMembers()
        {
            List<MemberListItem> memberList = wpe.Members.Select(m => new MemberListItem() { Id = m.Id, Name = m.Name }).ToList();
           
           return memberList;
        }
    }
}